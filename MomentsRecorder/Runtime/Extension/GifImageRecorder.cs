// Author : tkaria
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Moments.Encoder;
using ThreadPriority = System.Threading.ThreadPriority;


namespace Moments
{

    public class GifImageRecorder : MonoBehaviour
    {

        #region Event

        public Func<Texture2D> OnCaptureImageHandler;
        public Func<byte[], IEnumerator> OnCompletedHandler;
        public Action<int, float> OnProgressToGifProcess;

        #endregion // Event End.

        #region Property

        public RecorderState State { get; private set; }

        #endregion // Property End.

        #region Field

        [SerializeField, Range(1, 30)] int m_FramePerSecond = 15;
        [SerializeField, Moments.Min(-1)] int m_Repeat = 0;
        [SerializeField, Range(1, 100)] int m_Quality = 15;
        [SerializeField, Moments.Min(0.1f)] float m_BufferSize = 3f;
        
        private int m_MaxFrameCount;
        private float m_Time;
        private float m_TimePerFrame;
        private List<GifFrame> captureList = new List<GifFrame>();
        public ThreadPriority WorkerPriority = ThreadPriority.BelowNormal;

        #endregion // Field End.

        #region Method

        /// <summary>
        /// Used to reset internal values, called on Start(), Setup() and FlushMemory()
        /// </summary>
        private void InitializeParameter()
        {
            State = RecorderState.Paused;
            m_MaxFrameCount = Mathf.RoundToInt(m_BufferSize * m_FramePerSecond);
            m_TimePerFrame = 1f / m_FramePerSecond;
            m_Time = 0f;
        }

        /// <summary>
        /// Starts or resumes recording. You can't resume while it's pre-processing data to be saved.
        /// </summary>
        public void StartRecording()
        {
            if (State == RecorderState.PreProcessing)
            {
                Debug.LogWarning("Attempting to resume recording during the pre-processing step.");
                return;
            }

            InitializeParameter();
            State = RecorderState.Recording;
            StartCoroutine(OnRecording(OnCaptureImageHandler));
        }

        /// <summary>
        /// Saves the stored frames to a gif file. If the filename is null or empty, an unique one
        /// will be generated. You don't need to add the .gif extension to the name. Recording will
        /// be paused and won't resume automatically. You can use the <code>OnPreProcessingDone</code>
        /// callback to be notified when the pre-processing step has finished.
        /// </summary>
        public void StopRecording()
        {
            if (State == RecorderState.PreProcessing)
            {
                Debug.LogWarning("Attempting to save during the pre-processing step.");
                return;
            }

            State = RecorderState.PreProcessing;
            StartCoroutine(OnCreateGifProcess());
        }

        #region Coroutine

        /// <summary>
        /// image record process.
        /// </summary>
        private IEnumerator OnRecording(Func<Texture2D> onCaptureImage)
        {
            while(State == RecorderState.Recording)
            {
                if(onCaptureImage == null)
                {
                    yield return null;
                }

                m_Time += Time.unscaledDeltaTime;

                if (m_Time >= m_TimePerFrame)
                {
                    m_Time -= m_TimePerFrame;

                    yield return new WaitForEndOfFrame();
                    var target = onCaptureImage();
                    captureList.Add( new GifFrame(){ Width = target.width, Height = target.height, Data = target.GetPixels32() } );
                }
                yield return null;
            }
        }

        /// <summary>
        /// Pre-processing coroutine to extract frame data and send everything to a separate worker thread
        /// <summary>
        private IEnumerator OnCreateGifProcess()
        {
            // Switch the state to pause, let the user choose to keep recording or not
            State = RecorderState.Paused;

            // Setup a worker thread and let it do its magic
            GifEncoder encoder = new GifEncoder(m_Repeat, m_Quality);
            encoder.SetDelay(Mathf.RoundToInt(m_TimePerFrame * 1000f));
            var worker = new Worker(WorkerPriority)
            {
                m_Encoder = encoder,
                m_Frames = captureList,
                m_OnProgressHandler = OnProgressToGifProcess
            };
            worker.Start();

            yield return new WaitUntil(() => { return worker.IsComplete; } );
            yield return OnCompletedHandler(worker.GifImage);
        }

        #endregion // Coroutine End.

        #endregion // Method End.

    }
}

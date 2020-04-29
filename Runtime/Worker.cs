/*
 * Copyright (c) 2015 Thomas Hourdel
 *
 * This software is provided 'as-is', without any express or implied
 * warranty. In no event will the authors be held liable for any damages
 * arising from the use of this software.
 *
 * Permission is granted to anyone to use this software for any purpose,
 * including commercial applications, and to alter it and redistribute it
 * freely, subject to the following restrictions:
 * 
 *    1. The origin of this software must not be misrepresented; you must not
 *    claim that you wrote the original software. If you use this software
 *    in a product, an acknowledgment in the product documentation would be
 *    appreciated but is not required.
 * 
 *    2. Altered source versions must be plainly marked as such, and must not be
 *    misrepresented as being the original software.
 * 
 *    3. This notice may not be removed or altered from any source
 *    distribution.
 */

using UnityEngine;
using System;
using System.Collections.Generic;
using System.Threading;
using AriaPlugin.Runtime.GifMaker.Encoder;
using ThreadPriority = System.Threading.ThreadPriority;

namespace AriaPlugin.Runtime.GifMaker
{
	internal sealed class Worker
	{
		static int workerId = 1;

		Thread m_Thread;
		int m_Id;
		bool isWorking = false;

		internal List<GifFrame> m_Frames;
		internal GifEncoder m_Encoder;
		internal Action<int, float> m_OnProgressHandler;

		private byte[] gifBinaryImage = null;

		public byte[] GifImage
		{
			get { return gifBinaryImage; }
		}

		public bool IsComplete
		{
			get { return !isWorking; }
		}
		
		internal Worker(ThreadPriority priority)
		{
			m_Id = workerId++;
			m_Thread = new Thread(Run);
			m_Thread.Priority = priority;
		}

		internal void Start()
		{
			m_Thread.Start();
			isWorking = true;
		}

		void Run()
		{
			m_Encoder.Start( ( bytes ) => {  gifBinaryImage = new byte[bytes.Length]; bytes.CopyTo(gifBinaryImage,0); } );

			for (int i = 0; i < m_Frames.Count; i++)
			{
				GifFrame frame = m_Frames[i];
				m_Encoder.AddFrame(frame);

				if (m_OnProgressHandler != null)
				{
					float percent = (float)i / (float)m_Frames.Count;
					m_OnProgressHandler(m_Id, percent);
				}
			}

			m_Encoder.Finish();					
			isWorking = false;
		}
	}
}

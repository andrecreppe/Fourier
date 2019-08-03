using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawingController : MonoBehaviour
{
    private Vector3 centerPosition;
    private readonly int arraySize = 100;
    private bool run;

    public int[] signal;
    public float[] freq, amp, phase;
    public float[,] dftData;
    public GameObject center;

    //---------------------------------------------

    private void Start()
    {
        run = false;

        signal = new int[arraySize];
        for(int i=0; i<100; i++)
        {
            signal[i] = i;
        }

        freq = new float[arraySize];
        amp = new float[arraySize];
        phase = new float[arraySize];

        dftData = new float[arraySize, arraySize];

        DFT();

        run = true;
    }

    private void FixedUpdate()
    {
        if(run)
            Rotate();
    }

    //---------------------------------------------

    private void DFT()
    {
        int N = signal.Length;

        float real, img, phi;

        for(int k=0; k<N; k++)
        {
            real = 0;
            img = 0;

            for(int n=0; n<N; n++)
            {
                phi = (Mathf.PI * 2 * k * n) / N;

                real += signal[n] * Mathf.Cos(phi);
                img -= signal[n] * Mathf.Sin(phi);
            }

            real /= N;
            img /= N;

            dftData[k,0] = real;
            dftData[k,1] = img;

            freq[k] = k;
            amp[k] = Mathf.Sqrt((real * real) + (img * img));
            phase[k] = Mathf.Atan2(img, real);
        }
    }

    private void Rotate()
    {
        float rotateX, rotateY;
        float theta = (Mathf.PI * 2) / freq.Length;

        for(int i=0; i<100; i++)
        {
            rotateX = amp[i] * Mathf.Cos((freq[i] * theta) + phase[i] + (Mathf.PI / 2));
            rotateY = amp[i] * Mathf.Cos((freq[i] * theta) + phase[i] + (Mathf.PI / 2));

            transform.position = new Vector3(centerPosition.x + rotateX, centerPosition.y + rotateY);
        }
    }
}

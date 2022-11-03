namespace MyPractice.JobSystem
{
    using UnityEngine;
    using Unity.Collections;
    using Unity.Jobs;

    public class SceneMain : MonoBehaviour
    {
        public const int JOB_COUNT = 10;

        private MyJob job = new MyJob();

        private void Start()
        {
            job.input  = new NativeArray<int>(1, Allocator.TempJob);
            job.output = new NativeArray<int>(1, Allocator.TempJob);
        }

        private void Update()
        {
            Job();
        }

        private void OnDestroy()
        {
            job.input.Dispose();
            job.output.Dispose();
        }

        private void Job()
        {
            job.input[0] = 1;

            JobHandle handle = job.Schedule();

            handle.Complete(); // lock
        }

        private void NoJob()
        {
            _input[0] = 1;

            Execute();
        }

        private int[] _input = new int[1];
        private int[] _output = new int[1];

        private void Execute()
        {
            int a = 1;

            for (int i = 0; i < 100000000; ++i)
            {
                a = a << 1;

                _output[0] = _input[0] + a;
            }
        }
    }
}
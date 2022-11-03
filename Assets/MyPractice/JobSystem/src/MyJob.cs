namespace MyPractice.JobSystem
{
    using Unity.Collections;
    using Unity.Jobs;

    public struct MyJob : IJob
    {
        [ReadOnly] public NativeArray<int> input;
        [WriteOnly] public NativeArray<int> output;

        public void Execute()
        {
            int a = 1;

            for (int i = 0; i < 100000000; ++i)
            {
                a = a << 1;

                output[0] = input[0] + a;
            }
        }
    }
}

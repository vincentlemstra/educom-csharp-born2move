namespace Organizer
{
    public class ShiftHighestSort<T>
    {
        private List<T> array = new List<T>();
        private IComparer<T> comparer;

        /// <summary>
        /// Sort an array using the functions below
        /// </summary>
        /// <param name="input">The unsorted array</param>
        /// <returns>The sorted array</returns>
        public List<T> Sort(List<T> input, IComparer<T> comparer)
        {
            this.array = new List<T>(input);
            this.comparer = comparer;
            SortFunction(0, array.Count - 1);
            return this.array;
        }

        /// <summary>
        /// Sort the array from low to high
        /// </summary>
        /// <param name="low">De index within this.array to start with</param>
        /// <param name="high">De index within this.array to stop with</param>
        private void SortFunction(int low, int high)
        {
            int n = high;
            for (int i = low; i <= high; i++)
            {
                for (int j = low; j <= n; j++)
                {
                    if ((j + 1) <= n)
                    {
                        if (comparer.Compare(array[j], array[j + 1]) > 0)
                        {
                            // swap index
                            T temp = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = temp;
                        }
                    }
                }
                n--;
            }
        }
    }
}
namespace Organizer
{
    public class RotateSort<T>
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
        ///
        /// </summary>
        /// <param name="low">De index within this.array to start with</param>
        /// <param name="high">De index within this.array to stop with</param>
        private void SortFunction(int low, int high)
        {
            throw new NotImplementedException();
        }

        ///
        /// Partition the array in a group 'low' digits (e.a. lower than a choosen pivot) and a group 'high' digits
        /// </summary>
        /// <param name="low">De index within this.array to start with</param>
        /// <param name="high">De index within this.array to stop with</param>
        /// <returns>The index in the array of the first of the 'high' digits</returns>
        private int Partitioning(int low, int high)
        {
            throw new NotImplementedException();
        }
    }
}
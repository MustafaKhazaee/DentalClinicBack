namespace DentalClinic.Domain.Common {
    public class PagedResult<T> {
        public int rowCount { get; set; }
        public int pageCount { get; set; }
        public int pageSize { get; set; }
        public int pageIndex { get; set; }
        public IList<T> list { get; set; }
        public PagedResult(int pageIndex, int pageSize, int rowCount) {
            this.pageIndex = pageIndex;
            this.pageSize = pageSize;
            this.rowCount = rowCount;
            this.pageCount =  (int) Math.Ceiling((double) rowCount / pageSize);
        }
        public PagedResult(){
            list = new List<T>();
        } // Do not delete this constructor
    }
}

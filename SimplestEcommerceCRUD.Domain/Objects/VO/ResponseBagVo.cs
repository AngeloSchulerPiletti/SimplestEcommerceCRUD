namespace SimplestEcommerceCRUD.Domain.Objects.VO
{
    public class ResponseBagVo<TEntity> : ResponseVo
    {
        public ResponseBagVo(
            TEntity entity, 
            string title, 
            string message, 
            bool isError = true) : 
            base(
                title, 
                message, 
                isError
                )
        {
            Entity = entity;
        }

        public TEntity Entity { get; set; }
    }
}

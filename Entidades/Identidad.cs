namespace Entidades
{
    public class Identidad
    {
        public Identidad(long id)
        {
            this.Id = id;
        }

        public long Id { get; set; }

        public override bool Equals(object obj)
        {
            if (obj as Identidad != null)
            {
                return ((Identidad)obj).Id == this.Id && this.Id != 0;
            }

            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}

namespace Module2
{
    public class Cereale : Aliment, IEmballage
    {
        public override void Conserver()
        {
            this.RangerDansLePlacard();
        }

        private void RangerDansLePlacard()
        {
        }

        public void Fermer()
        {
        }

        public void Ouvrir()
        {
        }
    }
}

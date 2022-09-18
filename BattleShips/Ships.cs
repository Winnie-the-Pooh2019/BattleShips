namespace BattleShips
{
    enum Rotation
    {
        HORIZONTAL,
        VERTICAL
    }

    abstract class Ship
    {
        public int count;
        public Rotation rotation = Rotation.HORIZONTAL;
        public Dictionary<(int, int), bool> body = new Dictionary<(int, int), bool>();
        public (int, int) position;
        public List<(int, int)> area = new List<(int, int)>();

        public virtual void rotate()
        {
            var types = (Rotation[])Enum.GetValues(typeof(Rotation));
            int index = Array.IndexOf<Rotation>(types, rotation);
            rotation = (types.Length == index) ? types[0] : types[index];
        }

        public bool isAlive() {
            return body.Values.ToList().Any(key => key);
        }

        public bool isDamaged() {
            return !body.Values.ToList().All(key => key);
        }

        public void move((int, int) newPosition) {
            (int, int) delta;
            delta.Item1 = newPosition.Item1 - position.Item1;
            delta.Item2 = newPosition.Item2 - position.Item2;

            area.ForEach(e => {
                e.Item1 += delta.Item1;
                e.Item2 += delta.Item2;
            });
            body.Keys.ToList().ForEach(e => {
                e.Item1 += delta.Item1;
                e.Item2 += delta.Item2;
            });
        }
    }

    class SingleShip : Ship
    {
        public SingleShip() {
            count = 4;
            position = (0, 0);
            body[position] = true;
            
            for (int i = position.Item1 - 1; i < body.Count + 1; i++)
                for (int j = position.Item1 - 1; j < body.Count + 1; j++)
                    area.Add((i, j));
        }

        public override void rotate()
        {
            base.rotate();

            
        }
    }
}

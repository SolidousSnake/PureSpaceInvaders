using Code.Unit.Enemy;

namespace Code.Core.Factories
{
    public sealed class EnemyFactory : Factory<Enemy>
    {
        public EnemyFactory(Enemy enemy) : base(enemy)
        {

        }
    }
}

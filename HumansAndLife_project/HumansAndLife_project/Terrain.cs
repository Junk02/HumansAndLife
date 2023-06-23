
namespace HumansAndLife_project
{
    internal class Terrain
    {
        public GameObject current_obj = null;

        public bool IsFree()
        {
            return current_obj == null;
        }
    }
}

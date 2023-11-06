using Code.Score.View;

namespace Code.Score.Model
{
    public sealed class ScoreModel
    {
        private readonly ScoreView _view;

        private int _score = 0;

        public ScoreModel(ScoreView view)
        {
            _view = view;
        }

        public void IncrementScore(int value)
        {
            if (value < 0)
                return;

            _score += value;
            _view.SetAmount(_score);
        }
    }
}
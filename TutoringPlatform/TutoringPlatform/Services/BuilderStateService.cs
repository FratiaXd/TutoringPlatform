namespace TutoringPlatform.Services
{
    public class BuilderStateService
    {
        private string _courseTitle = "Course draft";
        private int _courseId;
        public string CourseTitle
        {
            get => _courseTitle;
            set
            {
                if (_courseTitle != value)
                {
                    _courseTitle = value;
                    NotifyStateChanged();
                }
            }
        }

        public int CourseId
        {
            get => _courseId;
            set
            {
                if (_courseId != value)
                {
                    _courseId = value;
                    NotifyStateChanged();
                }
            }
        }

        public event Action OnChange;

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}

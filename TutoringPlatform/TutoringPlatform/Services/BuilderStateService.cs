namespace TutoringPlatform.Services
{
    public class BuilderStateService
    {
        private string _courseTitle = "Course draft";
        private int _courseId;
        private Dictionary<int, string> _lessonTitles = new Dictionary<int, string>();

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

        public void UpdateLessonTitle(int lessonId, string title)
        {
            _lessonTitles[lessonId] = title;
            NotifyStateChanged();
        }

        public string GetLessonTitle(int lessonId)
        {
            if (_lessonTitles.ContainsKey(lessonId))
            {
                return _lessonTitles[lessonId];
            }
            return string.Empty;
        }

        public event Action OnChange;

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}

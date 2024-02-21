using TutoringPlatform.Shared.Models;

namespace TutoringPlatform.Services
{
    public class BuilderStateService
    {
        private string _courseTitle = "Course draft";
        private int _courseId;
        private Dictionary<int, Lesson> _lessons = new Dictionary<int, Lesson>();

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

        public void UpdateLesson(int lessonId, Lesson lesson)
        {
            _lessons[lessonId] = lesson;
            NotifyStateChanged();
        }

        public Lesson GetLesson(int lessonId)
        {
            if (_lessons.ContainsKey(lessonId))
            {
                return _lessons[lessonId];
            }
            return null;
        }

        public event Action OnChange;

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}

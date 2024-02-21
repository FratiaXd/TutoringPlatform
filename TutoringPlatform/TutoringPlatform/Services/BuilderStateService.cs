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

        public void ClearCourseState()
        {
            _courseId.Equals(0);
            _lessons.Clear();
            NotifyStateChanged();
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

        public void DeleteLesson(int lessonId)
        {
            if (_lessons.ContainsKey(lessonId))
            {
                var deletedOrder = _lessons[lessonId].LessonOrder;

                _lessons.Remove(lessonId);

                foreach (var lesson in _lessons.Values)
                {
                    if (lesson.LessonOrder > deletedOrder)
                    {
                        lesson.LessonOrder--;
                    }
                }
                NotifyStateChanged();
            }
        }

        public void DeleteQuiz(int quizId)
        {
            foreach (var lesson in _lessons.Values)
            {
                if (lesson.Quiz != null && lesson.Quiz.QuizId == quizId)
                {
                    lesson.Quiz = null; // Remove the quiz from the lesson
                    NotifyStateChanged();
                    return; // No need to continue searching if the quiz is found and removed
                }
            }
        }

        public void DeleteAssignment(int assignmentId)
        {
            foreach (var lesson in _lessons.Values)
            {
                if (lesson.Assignment != null && lesson.Assignment.AssignmentId == assignmentId)
                {
                    lesson.Assignment = null; // Remove the assignment from the lesson
                    NotifyStateChanged();
                    return; // No need to continue searching if the assignment is found and removed
                }
            }
        }

        public event Action OnChange;

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}

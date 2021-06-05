using HiL_Store.Commands;
using HiL_Store.Domain.Entities.QuizEntities;
using HiL_Store.Domain.Interfaces.CreationService;
using HiL_Store.Domain.Interfaces.Repository;
using HiL_Store.State.Navigators;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace HiL_Store.ViewModels
{
    public class AdminViewModel : ViewModelBase
    {

		private string _categoryName;
		public string CategoryName
		{
			get => _categoryName;
			set
			{
				_categoryName = value;
				OnPropertyChanged(nameof(CategoryName));
			}
		}

		private string _countQuestions;
		public string CountQuestions
		{
			get => _countQuestions;
			set
			{
				_countQuestions = value;
				OnPropertyChanged(nameof(CountQuestions));
			}
		}

		private string _question;
		public string Question
		{
			get => _question;
			set
			{
				_question = value;
				OnPropertyChanged(nameof(Question));
			}
		}

		private string _answerA;
		public string AnswerA
		{
			get => _answerA;
			set
			{
				_answerA = value;
				OnPropertyChanged(nameof(AnswerA));
			}
		}

		private string _answerB;
		public string AnswerB
		{
			get => _answerB;
			set
			{
				_answerB = value;
				OnPropertyChanged(nameof(AnswerB));
			}
		}

		private string _answerC;
		public string AnswerC
		{
			get => _answerC;
			set
			{
				_answerC = value;
				OnPropertyChanged(nameof(AnswerC));
			}
		}

		private string _answerD;
		public string AnswerD
		{
			get => _answerD;
			set
			{
				_answerD = value;
				OnPropertyChanged(nameof(AnswerD));
			}
		}

		private string _correctAns;
		public string CorrectAns
		{
			get => _correctAns;
			set
			{
				_correctAns = value;
				OnPropertyChanged(nameof(CorrectAns));
			}
		}

		IEnumerable<Category> _GetCollection;
		public IEnumerable<Category> GetCollection
		{
			get => _GetCollection;
			set
			{
				_GetCollection = value;
				OnPropertyChanged("GetCollection");
			}
		}


		private Category _category;
		public Category Category
		{
			get => _category;			
			set
			{
				_category = value;
				OnPropertyChanged(nameof(Category));
			}
		}

		public MessageViewModel ErrorMessageViewModel { get; }

		public string ErrorMessage
		{
			set => ErrorMessageViewModel.Message = value;
		}

		public MessageViewModel ErrorMessageViewModel2 { get; }

		public string ErrorMessage2
		{
			set => ErrorMessageViewModel2.Message = value;
		}


		public ICommand ViewLoginCommand { get; }
		public ICommand CategoryCreationCommand { get; }
		public ICommand QuizCreationCommand { get; }
		public ICommand CountQuestionsCreationCommand { get; }
		public ICommand CategoryGetCommand { get; }
	

		public AdminViewModel(IRenavigator loginRenavigator, ICategoryCreationService categoryCreationService, IQuizCreationService quizCreationService,
			ICountQuestionsCreationService countQuestionsCreationService, ICategoryService categoryService)
        {
			ErrorMessageViewModel = new MessageViewModel();
			ErrorMessageViewModel2 = new MessageViewModel();

			CategoryCreationCommand = new CategoryCreationCommand(this, categoryCreationService);
			CountQuestionsCreationCommand = new CountQuestionsCreationCommand(this, countQuestionsCreationService);
			QuizCreationCommand = new QuizCreationCommand(this, quizCreationService);
			ViewLoginCommand = new RenavigateCommand(loginRenavigator);
			CategoryGetCommand = new CategoryGetCommand(this, categoryService);

			CategoryGetCommand.Execute(categoryService);
		}

	}
}

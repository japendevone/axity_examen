using System;

namespace ExamService.Application.Seed
{
    public class ApplicationException : Exception
    {
        #region Private Members

        private string _message;

        #endregion

        #region Properties

        public int Code { get; set; }

        #endregion

        #region Constructor Members

        public ApplicationException(string message)
            : base(message)
        {
            _message = message;
        }

        public ApplicationException(int code, string message)
            : base(message)
        {
            Code = code;
            _message = message;
        }

        #endregion
    }
}
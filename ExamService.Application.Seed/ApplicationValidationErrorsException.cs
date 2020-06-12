using ExamService.Application.Seed.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamService.Application.Seed
{
    public class ApplicationValidationErrorsException : Exception
    {
        #region Members
        int _code;
        IEnumerable<string> _validationErrors;
        #endregion

        #region Properties
        public int Code
        {
            get { return this._code; }
            set { this._code = value; }
        }

        public IEnumerable<string> ValidationErrors
        {
            get
            {
                return _validationErrors;
            }
        }
        #endregion

        #region Constructor
        public ApplicationValidationErrorsException(int code, IEnumerable<string> validationErrors)
            : base(Messages.exception_ApplicationValidationExceptionDefaultMessage)
        {
            _code = code;
            _validationErrors = validationErrors;
        }
        #endregion
    }
}

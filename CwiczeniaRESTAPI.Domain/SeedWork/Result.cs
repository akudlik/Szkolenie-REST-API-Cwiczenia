using System.Collections.Generic;

namespace CwiczeniaRESTAPI.SeedWork
{
    public class Result<T> : Result
    {
        public T Value { get; }

        private Result(T value, bool isSuccessed, IEnumerable<Error> errorList) : base(isSuccessed, errorList)
        {
            Value = value;
        }

        public static Result<T> Ok(T value)
        {
            return new Result<T>(value, true, null);
        }

        public static Result Fail(IEnumerable<Error> errorList)
        {
            return new Result<T>(default(T), false, errorList);
        }
    }

    public class Result
    {
        public IEnumerable<Error> ErrorList { get; }
        public bool Successed { get; }

        protected Result(bool isSuccessed, IEnumerable<Error> errorList)
        {
            Successed = isSuccessed;
            ErrorList = errorList;
        }

        public static Result Ok()
        {
            return new Result(true, null);
        }

        public static Result Fail(IEnumerable<Error> errorList)
        {
            return new Result(false, errorList);
        }
    }

    public class Error
    {
        public int Code { get; set; }

        public string Description { get; set; }

        public Error(int code, string description)
        {
            Code = code;
            Description = description;
        }
    }
}
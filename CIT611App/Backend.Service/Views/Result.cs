﻿using System;

namespace Backend.Service.Common.Views
{
    public class Result<TValue, TError>
    {
        public readonly TValue Value;
        public readonly TError Error;

        private bool isSuccess;
        public bool IsSuccess { get => isSuccess; }

        private Result(TValue value)
        {
            isSuccess = true;
            Value = value;
            Error = default;
        }
        private Result(TError error)
        {
            isSuccess = false;
            Value = default;
            Error = error;
        }

        public static implicit operator Result<TValue, TError>(TValue value)
            => new(value);
        public static implicit operator Result<TValue, TError>(TError error)
            => new(error);

        public Result<TValue, TError> Match(Func<TValue, Result<TValue, TError>> success,
            Func<TError, Result<TValue, TError>> failure)
        {
            if (isSuccess) { return success(Value); }
            else { return failure(Error); }
        }
    }
}

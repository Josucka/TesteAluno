﻿namespace TesteAluno.APIResponse
{
    public class APIResponse<T>
    {
        public bool Succeed { get; set; }

        public string Message { get; set; }

        public T Result { get; set; }
    }
}
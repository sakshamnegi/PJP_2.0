using System.Collections.Generic;
using DateTimeCalculator.Models;

namespace DateTimeCalculator.Services
{
    public interface IInputReader
    {
        List<InputEntity> ReadMultipleInputs();

        InputEntity ReadSingleInput();

    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var result = ConverToDecimal(firstNumber) + ConverToDecimal(secondNumber);
                return Ok(result.ToString());
            }
            return BadRequest("Invalid input");
        }

        [HttpGet("subtraction/{firstNumber}/{secondNumber}")]
        public IActionResult Subtraction(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var result = ConverToDecimal(firstNumber) - ConverToDecimal(secondNumber);
                return Ok(result.ToString());
            }
            return BadRequest("Invalid input");
        }

        [HttpGet("multiplication/{firstNumber}/{secondNumber}")]
        public IActionResult Multiplication(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var result = ConverToDecimal(firstNumber) * ConverToDecimal(secondNumber);
                return Ok(result.ToString());
            }
            return BadRequest("Invalid input");
        }

        [HttpGet("division/{firstNumber}/{secondNumber}")]
        public IActionResult Division(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var result = ConverToDecimal(firstNumber) / ConverToDecimal(secondNumber);
                return Ok(result.ToString());
            }
            return BadRequest("Invalid input");
        }

        [HttpGet("mean/{firstNumber}/{secondNumber}")]
        public IActionResult Mean(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var result = (ConverToDecimal(firstNumber) + ConverToDecimal(secondNumber)) / 2;
                return Ok(result.ToString());
            }
            return BadRequest("Invalid input");
        }

        [HttpGet("squareRoot/{value}")]
        public IActionResult SquareRoot(string value)
        {
            if (IsNumeric(value))
            {
                var result = Math.Sqrt((double)ConverToDecimal(value));
                return Ok(result.ToString());
            }
            return BadRequest("Invalid input");
        }

        [HttpGet("imc/{weight}/{height}")]
        public IActionResult IMC(string weight, string height)
        {
            if (IsNumeric(weight) && IsNumeric(height))
            {
                var result = ConverToDecimal(weight) / (ConverToDecimal(height) * ConverToDecimal(height));
                return Ok("Magreza, quando o resultado é menor que 18,5 kg/m2" + Environment.NewLine
                    + "Normal, quando o resultado está entre 18, 5 e 24, 9 kg/m2" + Environment.NewLine
                    + "Sobrepeso, quando o resultado está entre 24,9 e 30 kg/m2" + Environment.NewLine
                    + "Obesidade, quando o resultado é maior que 30 kg/m2" + Environment.NewLine 
                    + $"Resultado: {result}");
            }
            return BadRequest("Invalid input");
        }

        private static decimal ConverToDecimal(string strNumber)
        {
            if (decimal.TryParse(strNumber, out decimal decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }

        private static bool IsNumeric(string strNumber)
        {
            bool isNumber = double.TryParse(strNumber,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out _);
            return isNumber;
        }
    }
}

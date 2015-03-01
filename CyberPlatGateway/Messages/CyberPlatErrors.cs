using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberPlatGateway.Messages
{
    public class CyberPlatException : Exception
    {
        private readonly int _errorCode;

        public CyberPlatException(int code)
        {
            _errorCode = code;
        }
        public override string ToString()
        {
            switch (_errorCode)
            {
                case 1:
                {
                    return "Сессия с таким номером уже существует";
                    break;
                }
                case 2:
                {
                    return "Неверный код контрагента";
                    break;
                }
                case 3:
                {
                    return "Неверный код точки приема";
                    break;
                }
                case 4:
                {
                    return "Неверный код оператора точки приема";
                    break;
                }
                case 5:
                {
                    return "Неверный формат кода сессии";
                    break;
                }
                case 6:
                {
                    return "Неверная АСП";
                    break;
                }
                case 7:
                {
                    return "Неверный формат или значение суммы к оплате";
                    break;
                }
                    //TODO: Дописать оставшиеся варианты ошибок 
                default:
                    return "Неизветная ошибка";
            }
        }
    }
}

using System;
using System.Linq;
using cipherNg.Models;
using Microsoft.Extensions.DependencyInjection;

namespace cipherNg.Services
{
    public class EncoderWithArray : IEncoder
    {
        private readonly IServiceScopeFactory scopeFactory;

        public EncoderWithArray(IServiceScopeFactory scopeFactory)
        {
            this.scopeFactory = scopeFactory;
        }

        public string MakeEncode(string origstr)
        {
            using (var scope = scopeFactory.CreateScope())
            {
                var rRules = scope.ServiceProvider.GetRequiredService<IRepository<ReplacementRule>>();

                //Ищем все правила для замены
                var AllRules = rRules.Get();

                //переводим введеную строку в массив чаров 
                char[] charAr = origstr.ToCharArray();

                //Посимвольно применяем правило замены
                for (int i = 0; i < charAr.Length; i++)
                {
                    var rule = AllRules.Where(p => p.OldSymbol == charAr[i]).FirstOrDefault();
                    //Если для очередного символа найден заменитель - меняем.
                    if (rule != null)
                    {
                        charAr[i] = rule.NewSymbol;
                    }
                }
                //По окончанию логируем, собираем новую зашифрованную строку, передаем клиенту
                LogNow(origstr);
                return String.Concat<char>(charAr);
            }
        }
        
        //Добавляем запись в таблицу логирования
        public void LogNow(string origstr)
        {
            EnctiptionLog newLog = new EnctiptionLog() { Text = origstr, dateTime = DateTime.Now };
            using (var scope = scopeFactory.CreateScope())
            {
                var rLog = scope.ServiceProvider.GetRequiredService<IRepository<EnctiptionLog>>();
                rLog.Create(newLog);
            }
        }
    }
}
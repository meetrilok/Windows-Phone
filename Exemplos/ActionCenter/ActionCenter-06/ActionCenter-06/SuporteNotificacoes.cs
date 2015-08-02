using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// ====================================================================
// Inclusao Obrigatoria
// ====================================================================

using Windows.UI.Notifications;
using System.Diagnostics;
using Windows.Data.Xml.Dom;

namespace ActionCenter_06
{
    class SuporteNotificacao
    {
        public static bool ToastLiberado()
        {
            bool bEnvio = true;
            var Notificador = ToastNotificationManager.CreateToastNotifier();

            if (Notificador.Setting != NotificationSetting.Enabled)
            {
                string strMotivo = "Não Conhecido";
                switch (Notificador.Setting)
                {
                    case NotificationSetting.DisabledByGroupPolicy:
                        strMotivo = "O administrador desativou todas as notificações neste Smartphone através da política de grupo. A definição da política de grupo substitui configuração do usuário.";
                        break;

                    case NotificationSetting.DisabledByManifest:
                        strMotivo = "Para ser capaz de enviar um Toast, defina a opção Toast Capable para YES no arquivo Package.appxmanifest deste aplicativo.";
                        break;

                    case NotificationSetting.DisabledForApplication:
                        strMotivo = "O usuário desativou as notificações para esta app.";
                        break;

                    case NotificationSetting.DisabledForUser:
                        strMotivo = "O usuário ou administrador desabilitou todas as notificações para este usuário neste smartphone.";
                        break;
                }

                string strErroMsg = String.Format("Can't send a toast.\n{0}", strMotivo);
                Debug.WriteLine("[MSG] " + strErroMsg);
                bEnvio = false;
            }

            return bEnvio;
        }

        public static ToastNotification CriaNotificacaoTexto(string toastHeading, string toastBody)
        {
            ToastTemplateType toastTemplate = ToastTemplateType.ToastText02;
            XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(toastTemplate);
            XmlNodeList toastTextElements = toastXml.GetElementsByTagName("text");

            toastTextElements[0].AppendChild(toastXml.CreateTextNode(toastHeading));
            toastTextElements[1].AppendChild(toastXml.CreateTextNode(toastBody));

            IXmlNode toastNode = toastXml.SelectSingleNode("/toast");
            ((XmlElement)toastNode).SetAttribute("duration", "long");
            ToastNotification toast = new ToastNotification(toastXml);

            return toast;
        }
    }
}

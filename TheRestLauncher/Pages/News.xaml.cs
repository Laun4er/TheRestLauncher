using Discord;
using Discord.WebSocket;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Image = System.Windows.Controls.Image;

namespace TheRestLauncher.Pages
{

    public partial class News : Page
    {
        // Ваш токен бота Discord
        private const string BotToken = "OTg0MTQ5ODY2MzE1OTE5NDEz.GEwqNx.ByLG9SNNrTULHblxYty8B5FOc0QqWeNIUb-ww8";

        // ID канала, из которого вы хотите получать последнее сообщение
        private const ulong ChannelId = 1185924268702314536;

        

        // Клиент Discord.NET для подключения к Discord API
        private DiscordSocketClient _client;
        public News()
        {
            InitializeComponent();

        }
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Создаем новый клиент Discord.NET с настройками
            _client = new DiscordSocketClient(new DiscordSocketConfig
            {
                // Логгируем все события
                LogLevel = LogSeverity.Info
            });

            // Подписываемся на событие готовности клиента
            _client.Ready += Client_Ready;

            // Подписываемся на событие получения нового сообщения
            _client.MessageReceived += Client_MessageReceived;

            // Подключаемся к Discord API с токеном бота
            await _client.LoginAsync(TokenType.Bot, BotToken);
            await _client.StartAsync();
        }
        private async Task Client_Ready()
        {
            // Выводим в консоль информацию о подключении
            Console.WriteLine($"Logged in as {_client.CurrentUser.Username}#{_client.CurrentUser.Discriminator}");
        }

        private async Task Client_MessageReceived(SocketMessage message)
        {
            // Проверяем, что сообщение пришло из нужного канала и не является системным
            if (message.Channel.Id == ChannelId && !message.Author.IsBot && !message.Author.IsWebhook)
            {
                // Вызываем метод для отображения сообщения в окне приложения
                // в основном потоке с помощью диспетчера
                Dispatcher.Invoke(() => DisplayMessage(message));
            }
        }

        private void DisplayMessage(SocketMessage message)
        {
            // Очищаем содержимое StackPanel, где будем отображать сообщение
            spMessage.Children.Clear();

            // Создаем новый TextBlock для имени пользователя
            var tbUsername = new TextBlock
            {
                Text = message.Author.Username,
                FontWeight = FontWeights.Bold,
                Margin = new Thickness(5)
            };

            // Добавляем TextBlock в StackPanel
            spMessage.Children.Add(tbUsername);

            // Создаем новый TextBlock для текста сообщения
            var tbContent = new TextBlock
            {
                Text = message.Content,
                TextWrapping = TextWrapping.Wrap,
                Margin = new Thickness(5)
            };

            // Добавляем TextBlock в StackPanel
            spMessage.Children.Add(tbContent);

            // Если в сообщении есть вложения, то перебираем их
            if (message.Attachments.Count > 0)
            {
                foreach (var attachment in message.Attachments)
                {
                    // Если вложение является изображением, то создаем новый Image для него
                    if (attachment.Width.HasValue && attachment.Height.HasValue)
                    {
                        var imgAttachment = new Image
                        {
                            Source = new BitmapImage(new Uri(attachment.Url)),
                            MaxWidth = 400,
                            MaxHeight = 400,
                            Margin = new Thickness(5)
                        };

                        // Добавляем Image в StackPanel
                        spMessage.Children.Add(imgAttachment);
                    }
                }
            }
        }
    }
}
    


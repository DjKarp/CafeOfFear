<p align="center">
  <img src="https://redleggames.com//Games/CafeOfFear/Icon.png" alt="Cafe on Fear Icon" width="256" height="256"/>
</p>

<h1 align="center">Cafe of Fear  — Atmospheric Unity Scene</h1>

<p align="center"><b>Короткий 5-минутный игровой опыт в уютном кафе с неожиданным поворотом..</b></p>
<br><br>
## 🎮 Описание

Игрок попадает в тёплое, ламповое кафе, где готовит кофе для посетителей. Всё начинается мирно — мягкий свет, уютная атмосфера.
Но по мере прохождения за рамками уюта начинают проявляться странности...

Сцену можно завершить 2мя способами:

- 1й - Приготовление кофе:
  - взять любой стакан,
  - поставить в кофемашину (дождаться завершения анимации и звукового сопровождения, раньше стакан вытащить не получится),
  - взять любую крышку и закрыть крышкой стакан,
  - передать NPC (кинуть в NPC - нажатием на правую кнопку мышки);
    
- 2й - отдавать посетителю 10 раз НЕ кофе;
  
- Эффект выдачи кофе: приятный звук и визуальный отклик (деньги/очки);
- Мини-сцена с кинематографичным скримером: неожиданный поворот в финале;
- Реализация через Unity URP, с эффектом VHS;

<br><br>
_Более подробное описание можно найти в текстовом файле:_ 

https://docs.google.com/document/d/1KHK1JVTqbyAuse-Fg4Mz5A5L2g30AIiGu_kZURyZS98/edit?usp=sharing

<br><br>

## ✨ Выполненные условия:
☕ Интерактивный процесс приготовления кофе;

🎭 NPC с выраженными эмоциями;

💡 Атмосферный тёплый свет и стиль VHS (с фильтрами);

🎥 Скриптованная камера с тревожной сценой;

⚠️ Лёгкий хоррор-элемент в финале (без жести, но с напряжением);

🔊 Аудио на FMOD: звуками озвучены все интерактивные элементы и события;

🎶 Музыкальное и звуковое сопровождение создают напряжённую и уютную атмосферу;

🖥️ FPS Overlay + Post-Processing эффекты;

<br><br>

## 🧰 Как запустить

Скачай архив, распакуй и запусти готовый Build:

https://github.com/DjKarp/CafeOfFear/releases

https://drive.google.com/file/d/1j5J9bLb_fav-6-gnc_OQJc19tW1c7BhG/view?usp=sharing

<br><br>

Склонируй проект:

https://github.com/DjKarp/CafeOfFear.git

Открыть в Unity 2022.3+ (URP)

Установить Zenject, DOTween, TMPro, QuickOutline

Сцена запуска: Bootstrap, Gameplay

Играй! 🎉

<br><br>

## 📁 Структура проекта
<pre> ```Assets/
├── _Project/                  
│   ├── Scripts                
│   │  ├── Audio/              # AudioService для запуска и работой с евентами
│   │  ├── Environment/        # Компоненты Темноты за окнами, Монстра в окне
│   │  ├── Input/              # Движение персонажа и считывание нажатий с клавиатуры. 
│   │  ├── Installers/         # Zenject Installer'ы
│   │  ├── Items/              # GiveCash для работы с всплывающим окошком получения денег
│   │  │  ├── CoffeeMachine    # Скрипт места для приготовлдения кофе - помещает стакан в себя и готовит кофе
│   │  │  ├── OutlineItems     # Родитеский компонент свечения и потомки с реализацией разных звуков падения.
│   │  │  └── PapperCup        # Интерфейсы и компонентфы для взаимодействия с предметами
│   │  ├── Person/             # Сервисы анимаций, принятия предметов, текста и основной скрипт с данными и посетителе
│   │  ├── Player/             # Работа с предметами, движение и вращение головой
│   │  ├── Presenter/          # Отвечает за старт скримера, управляет камерами и светом
│   │  ├── Signals/            # Zenject сигналы для реагирования на тестовый UI, для примера
│   │  └── UI/                 # FadeService - появление и уход в темноту игрока, выход из игры, счётчик FPS и отображение наличности игрока
│   └── Settings               # URP профили
├── Animations/                # Анимации посетителя и наполнения стакана кофе
├── Art/                       # 3D модели, материалы и текстуры
│   ├── 3D_Character           # Монстры, посетитель - 3D модели, материалы и текстуры
│   ├── 3D_Environment         # Окружение, кафешка, интерактивные объекты и камера с монитором
│   └── Logo                   # Иконка, Лого в загрузочную сцену и надпись
├── Audio/                     # FMOD проект - оставил его полностью, чтобы продемонстрировать навыки работы и с движком
├── Prefabs/                   # Префабы игрока, посетителя и окна с отображением полученых денег
├── Resources/                 # DOTweenSettings и URP assets
├── Scenes/                    # Все сцены игры 
│   ├── Bootstrap              # Разгоночная сцена, содержит только загрузочный экран, с неё запускаются все остальные сцены
│   └── Gameplay               # Сцена с геймплеем
└── StreamingAssets/           # Банки FMOD проекта
``` </pre>
---

<br><br>

## 🎥 Скриншоты

<p align="center">
  <img src="https://redleggames.com/Games/CafeOfFear/Screens/CafeOfFear_Screen_01.jpg" width="300"/>
  <img src="https://redleggames.com/Games/CafeOfFear/Screens/CafeOfFear_Screen_02.jpg" width="300"/>
  <img src="https://redleggames.com/Games/CafeOfFear/Screens/CafeOfFear_Screen_03.jpg" width="300"/>
  <img src="https://redleggames.com/Games/CafeOfFear/Screens/CafeOfFear_Screen_04.jpg" width="300"/>
  <img src="https://redleggames.com/Games/CafeOfFear/Screens/CafeOfFear_Screen_05.jpg" width="300"/>
  <img src="https://redleggames.com/Games/CafeOfFear/Screens/CafeOfFear_Screen_06.jpg" width="300"/>
  <img src="https://redleggames.com/Games/CafeOfFear/Screens/CafeOfFear_Screen_08.jpg" width="300"/>
  <img src="https://redleggames.com/Games/CafeOfFear/Screens/CafeOfFear_Screen_09.jpg" width="300"/>
</p>

<br><br>

## 🎥 GIF

<p align="center">
  <img src="https://redleggames.com/Games/CafeOfFear/Gif/CafeOfFear_Gameplay_cut_001.gif"/>
  <img src="https://redleggames.com/Games/CafeOfFear/Gif/CafeOfFear_Gameplay_cut_002.gif"/>
  <img src="https://redleggames.com/Games/CafeOfFear/Gif/CafeOfFear_Gameplay_cut_003.gif"/>
</p>

<br><br>

## 🎥 Видео
<p align="center">
<b>Смотреть Gameplay видео на RuTube - https://rutube.ru/video/b656f16af6dac186e0bef3a73a8a62dd/ </b><br/>
</p>

<p align="center">
<b>Видео на Google Drive - https://drive.google.com/file/d/1Yp-j0jFbIQYki85q1phrySY5PFWgoI4B/view?usp=sharing </b><br/>
</p>
<br><br>
## 🛠️ Технологии
Unity 2022.3.23f1 (LTS);

URP (Universal Render Pipeline);

Custom Volume Profiles (VHS + уютный свет);

FMOD для интеграции звука и музыки;

Raycast-система выделения объектов в центре экрана;

Мини-менеджер скримеров и события;

Аудио-интерактив: каждый элемент и действие сопровождаются соответствующими звуками через FMOD

using System;

namespace GAME
{
    [Serializable]
    public class LevelSystemEvents
    {
        public Action NextCup;
        
        public Action LevelPreset;      // Загрузка LevelPreset
        public Action LevelLoad;        // Старт загрузки уровня
        public Action LevelClear;       // Очистка данных предыдущего уровня
        public Action LevelGenerate;    // Генерация уровня на основе LevelPreset
        public Action LevelInit;        // Инициализация созданных объектов на уровне
        public Action LevelLoaded;      // Конец загрузки уровня
        
        public Action LevelStart;       // Старт уровня
        public Action LevelFinish;      // Уровень завершён
        public Action LevelComplete;    // Уровень завершён победой
        public Action LevelFail;        // Уровень завершён проигрышем
        public Action LevelContinue;    // Продолжить уровень
        public Action LevelEnd;         // Конец уровня
        public Action LevelClaimRewards;
        public Action LevelFailClose;
        public Action LevelExit;        // Выход с уровня
        public Action LevelRestart;     // Перезапуск уровня
        public Action LevelNext;        // Следующий уровень
    }
}

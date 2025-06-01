using UnityEngine;
using FMODUnity;
using FMOD.Studio;

namespace CafeOfFear
{
    public class AudioService : MonoBehaviour
    {
        [SerializeField] private Camera _cameraPlayer;
        [SerializeField] private Camera _cameraCinemachine;
        private Camera _camera;

        //Music
        private string _horrorMusic = "event:/Music_Horror/Music";

        //Player
        private string _playerSteps = "event:/Player/PlayerSteps";
        private string _playerStepsParamName = "PlayerSteps";
        private float _playerStepsParam = 0.0f;
        private EventInstance _playerStepsInstance;

        private string _heartbeat = "event:/Player/Heart";
        private string _heartbeatParamName = "Heart";
        private float _heartbeatParam = 0.0f;
        private EventInstance _heartbeatInstance;

        //Items
        private string _coffeemachine = "event:/Items/Coffeemachine_Made_Coffe";
        private string _pickUpItem = "event:/Items/PickUpItem";
        private string _installCup = "event:/Items/Install_Cup";
        private string _installCupCap = "event:/Items/Install_CupCap";
        private string _throwingObject = "event:/Items/ThrowingObject";
        private string _fallItems = "event:/Items/FallItems";
        private string _soundLight = "event:/Person/AppearancePerson/Sound_Light_Loop";
        private string _cash = "event:/Items/Ñash";
        private string _cupFilled = "event:/Items/Finish_Filled_Cup";
        private string _forkDropped = "event:/Items/ForkDroppedToFloor";
        private string _glassFalling = "event:/Items/GlassFalling";

        public enum ItemSound { Coffeemachine, PickUp, Install_Cup, Install_CupCap, ThrowingObject, FallItems, SoundLight, Cash, Finish_Filled, ForkDropped, GlassFalling }

        //Person
        private string _stepHramoy = "event:/Person/Step_Hramoy";
        private EventInstance _stepHramoyInstance;
        private string _appearancePerson = "event:/Person/AppearancePerson/AppearancePerson";        
        private string _badItemPerson = "event:/Person/Bad_Item_For_Person_Attention";
        private string _personAngry = "event:/Person/Person_Angry";
        private string _personTakeCoffee = "event:/Person/Person_Take_Coffee";
        private string _personWalkBack = "event:/Person/PersonWalkBack";

        public enum PersonSound { Appearance, Bad_Item, Angry, Take_Coffee, WalkBack }

        //Screamer
        private string _changePersonOnFear = "event:/Sound_Screamer/ChangePersonOnFear";
        private string _finalFear = "event:/Sound_Screamer/SoundFinalFear";

        public enum FinalFearSound { ChangePerson, FinalFear }

        public void Init()
        {
            _camera = _cameraPlayer;

            RuntimeManager.PlayOneShotAttached(_horrorMusic, _camera.gameObject);

            _heartbeatInstance = RuntimeManager.CreateInstance(_heartbeat);
            _heartbeatInstance.set3DAttributes(RuntimeUtils.To3DAttributes(_camera.gameObject.transform));
            _heartbeatInstance.start();
            SetPlayerHeartParam(0.0f);

            _playerStepsInstance = RuntimeManager.CreateInstance(_playerSteps);
            _playerStepsInstance.set3DAttributes(RuntimeUtils.To3DAttributes(_camera.gameObject.transform));
            _playerStepsInstance.start();
            SetPlayerStepsParam(0.0f);
        }

        public void SetPlayerHeartParam(float heartbeatParam)
        {
            _heartbeatParam = Mathf.Clamp01(heartbeatParam);
            _heartbeatInstance.setParameterByName(_heartbeatParamName, _heartbeatParam);
        }

        public void SetPlayerStepsParam(float playerStepsParam)
        {
            _playerStepsParam = Mathf.Clamp01(playerStepsParam);
            _playerStepsInstance.setParameterByName(_playerStepsParamName, _playerStepsParam);
        }

        public void PlayItemSound(ItemSound itemSound, GameObject fromObject = null)
        {
            string soundEvent = _pickUpItem;

            switch (itemSound)
            {
                case ItemSound.Coffeemachine: soundEvent = _coffeemachine; break;
                case ItemSound.PickUp: soundEvent = _pickUpItem; break;
                case ItemSound.Install_Cup: soundEvent = _installCup; break;
                case ItemSound.Install_CupCap: soundEvent = _installCupCap; break;
                case ItemSound.ThrowingObject: soundEvent = _throwingObject; break;
                case ItemSound.FallItems: soundEvent = _fallItems; break;
                case ItemSound.SoundLight: soundEvent = _soundLight; break;
                case ItemSound.Cash: soundEvent = _cash; break;
                case ItemSound.Finish_Filled: soundEvent = _cupFilled; break;
                case ItemSound.ForkDropped: soundEvent = _forkDropped; break;
                case ItemSound.GlassFalling: soundEvent = _glassFalling; break;
            }

            RuntimeManager.PlayOneShotAttached(soundEvent, fromObject == null ? _camera.gameObject : fromObject);
        }

        public void PlayPersonSound(PersonSound personSound, GameObject fromObject = null)
        {
            string soundEvent = _pickUpItem;

            switch (personSound)
            {
                case PersonSound.Appearance: soundEvent = _appearancePerson; break;
                case PersonSound.Bad_Item: soundEvent = _badItemPerson; break;
                case PersonSound.Angry: soundEvent = _personAngry; break;
                case PersonSound.Take_Coffee: soundEvent = _personTakeCoffee; break;
                case PersonSound.WalkBack: soundEvent = _personWalkBack; break;
            }

            RuntimeManager.PlayOneShotAttached(soundEvent, fromObject == null ? _camera.gameObject : fromObject);
        }

        public void PlayFinalFearSound(FinalFearSound finalFearSound, GameObject fromObject = null)
        {
            string soundEvent = _pickUpItem;

            switch (finalFearSound)
            {
                case FinalFearSound.ChangePerson: soundEvent = _changePersonOnFear; break;
                case FinalFearSound.FinalFear: soundEvent = _finalFear; break;
            }

            RuntimeManager.PlayOneShotAttached(soundEvent, fromObject == null ? _camera.gameObject : fromObject);
        }

        public void StartPersonWalkToPlayer(Transform personTransform)
        {
            _stepHramoyInstance = RuntimeManager.CreateInstance(_stepHramoy);
            _stepHramoyInstance.set3DAttributes(RuntimeUtils.To3DAttributes(personTransform));
            _stepHramoyInstance.start();
        }

        public void StopPersonWalkToPlayer()
        {
            _stepHramoyInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        }

        public void ChangeCamera(bool isPlayer)
        {
            _camera = isPlayer ? _cameraPlayer : _cameraCinemachine;

            _heartbeatInstance.set3DAttributes(RuntimeUtils.To3DAttributes(_camera.gameObject.transform));
            _playerStepsInstance.set3DAttributes(RuntimeUtils.To3DAttributes(_camera.gameObject.transform));
        }
    }
}

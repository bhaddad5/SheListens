/////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Audiokinetic Wwise generated include file. Do not edit.
//
/////////////////////////////////////////////////////////////////////////////////////////////////////

#ifndef __WWISE_IDS_H__
#define __WWISE_IDS_H__

#include <AK/SoundEngine/Common/AkTypes.h>

namespace AK
{
    namespace EVENTS
    {
        static const AkUniqueID PLAY_BASELAYER = 4042215132U;
        static const AkUniqueID PLAY_CANDLEBURN = 921938950U;
        static const AkUniqueID PLAY_CREAKS = 1247850169U;
        static const AkUniqueID PLAY_DOOROPEN = 3197300806U;
        static const AkUniqueID PLAY_FOOTSTEP = 1602358412U;
        static const AkUniqueID PLAY_GLASS_SMASH = 727285159U;
        static const AkUniqueID PLAY_KEYBLIP = 3353471726U;
        static const AkUniqueID PLAY_KEYPICKUP = 885077343U;
        static const AkUniqueID PLAY_LIGHTBULB_BUZZ = 3859524437U;
        static const AkUniqueID PLAY_LIGHTBULB_METAL = 1449975651U;
        static const AkUniqueID PLAY_LIGHTBULB_ZAP = 1785283739U;
        static const AkUniqueID PLAY_MUSICENEMY = 786657857U;
        static const AkUniqueID PLAY_TEST = 3187507146U;
        static const AkUniqueID PLAY_WITCH_HUNTING = 3978663595U;
        static const AkUniqueID PLAY_WITCH_MOANS = 4038978142U;
        static const AkUniqueID PLAY_WITCH_SCREAM = 3058690321U;
        static const AkUniqueID PLAY_ZAPOFF = 1311566966U;
        static const AkUniqueID PLAY_ZAPON = 1839672760U;
    } // namespace EVENTS

    namespace STATES
    {
        namespace LIGHTS
        {
            static const AkUniqueID GROUP = 3192784746U;

            namespace STATE
            {
                static const AkUniqueID OFF = 930712164U;
                static const AkUniqueID ON = 1651971902U;
            } // namespace STATE
        } // namespace LIGHTS

        namespace WITCH
        {
            static const AkUniqueID GROUP = 760583530U;

            namespace STATE
            {
                static const AkUniqueID ATTACKING = 1641806523U;
                static const AkUniqueID GAMEOVER = 4158285989U;
                static const AkUniqueID HUNTING = 1225919746U;
                static const AkUniqueID IDLE = 1874288895U;
            } // namespace STATE
        } // namespace WITCH

    } // namespace STATES

    namespace SWITCHES
    {
        namespace FLOOR
        {
            static const AkUniqueID GROUP = 1088209313U;

            namespace SWITCH
            {
                static const AkUniqueID CARPET = 2412606308U;
                static const AkUniqueID GLASS = 2449969375U;
                static const AkUniqueID WOOD = 2058049674U;
            } // namespace SWITCH
        } // namespace FLOOR

    } // namespace SWITCHES

    namespace GAME_PARAMETERS
    {
        static const AkUniqueID CANDLESPEED = 204323119U;
        static const AkUniqueID HEADSPEED = 1893836608U;
        static const AkUniqueID WITCHDIST = 4007242070U;
    } // namespace GAME_PARAMETERS

    namespace BANKS
    {
        static const AkUniqueID INIT = 1355168291U;
        static const AkUniqueID MASTER = 4056684167U;
    } // namespace BANKS

    namespace BUSSES
    {
        static const AkUniqueID MASTER_AUDIO_BUS = 3803692087U;
        static const AkUniqueID MASTER_SECONDARY_BUS = 805203703U;
    } // namespace BUSSES

    namespace AUX_BUSSES
    {
        static const AkUniqueID NEW_AUXILIARY_BUS = 373392551U;
    } // namespace AUX_BUSSES

}// namespace AK

#endif // __WWISE_IDS_H__

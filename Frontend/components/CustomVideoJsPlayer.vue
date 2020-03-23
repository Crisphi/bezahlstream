<!---
  This `CustomVideoJsPlayer` component is a custom implementation of [Video.js 7](https://github.com/videojs/video.js).

  The recommended vue component [vue-video-player](https://github.com/surmon-china/vue-video-player) is still implementing
  Video.js < v7.0.0. To be able to support HLS (HTTP Live Streaming) for videos you either rely on deprecated plugins for
  Video.js or you upgrade to Video.js >= v7.0.0, which does already included the nitty-gritty streaming functionalities.
  See https://blog.videojs.com/video-js-7-is-here/ more infos.
  Literally, that's why this custom implementation has been invented. (⌐■_■)

  Usage Example:

    <video-player ref="videoPlayer"
                  :options="playerOptions"
                  @play="onPlayerPlay($event)"
                  @ready="onPlayerReady($event)">
    </video-player>

  Props:
  - crossOrigin: // TODO: write prop description
  - playsinline: // TODO: write prop description
  - customEventName: // TODO: write prop description
  - options: // TODO: write prop description
  - events: // TODO: write prop description
  - globalOptions: // TODO: write prop description
  - globalEvents: // TODO: write prop description
  - trackList: // TODO: write prop description

  Caveats:
  - Has to load its own little script file. Currently: https://addevent.com/libs/atc/1.6.1/atc.min.js
    <script type="text/javascript" src="https://addevent.com/libs/atc/1.6.1/atc.min.js" async defer></script>
-->
<template>
  <div v-if="reseted">
    <video ref="video" class="video-js">
      <track
        v-for="(crtTrack, index) in trackList"
        :key="index"
        :kind="crtTrack.kind"
        :label="crtTrack.label"
        :src="crtTrack.src"
        :srcLang="crtTrack.srcLang"
        :default="crtTrack.default"
      />
      <p class="vjs-no-js">
        To view this video please enable JavaScript, and consider upgrading to a
        web browser that
        <a href="https://videojs.com/html5-video-support/" target="_blank"
          >supports HTML5 video</a
        >
      </p>
    </video>
  </div>
</template>

<script>
import _videojs from 'video.js'
const videojs = /* window.videojs || */ _videojs

export default {
  name: 'CustomVideoJsPlayer',
  props: {
    crossOrigin: {
      type: String,
      default: ''
    },
    playsinline: {
      type: Boolean,
      default: false
    },
    customEventName: {
      type: String,
      default: 'statechanged'
    },
    options: {
      type: Object,
      required: true
    },
    events: {
      type: Array,
      default: () => []
    },
    globalOptions: {
      type: Object,
      default: () => ({
        // 查看文档: https://docs.videojs.com/tutorial-options.html#fluid
        autoplay: true,
        controls: true,
        language: 'zh',
        inactivityTimeout: 0,
        preload: 'auto',
        fluid: false,
        techOrder: ['html5'],
        plugins: {}
      })
    },
    globalEvents: {
      type: Array,
      default: () => []
    },
    trackList: {
      type: Array,
      default: () => []
    }
  },
  data() {
    return {
      player: null,
      reseted: true
    }
  },
  watch: {
    options: {
      deep: true,
      handler(options, oldOptions) {
        this.dispose(() => {
          if (options && options.sources && options.sources.length) {
            this.initialize()
          }
        })
      }
    }
  },
  mounted() {
    if (!this.player) {
      this.initialize()
    }
  },
  beforeDestroy() {
    if (this.player) {
      this.dispose()
    }
  },
  methods: {
    initialize() {
      const self = this
      const videoObj = this.$refs.video
      // videojs options
      const videoOptions = Object.assign({}, this.globalOptions, this.options)
      // ios fullscreen
      if (this.playsinline) {
        videoObj.setAttribute('playsinline', this.playsinline)
        videoObj.setAttribute('webkit-playsinline', this.playsinline)
        videoObj.setAttribute('x5-playsinline', this.playsinline)
        videoObj.setAttribute('x5-video-player-type', 'h5')
        videoObj.setAttribute('x5-video-player-fullscreen', false)
      }
      // cross origin
      if (this.crossOrigin !== '') {
        videoObj.crossOrigin = this.crossOrigin
        videoObj.setAttribute('crossOrigin', this.crossOrigin)
      }
      // avoid error "VIDEOJS: ERROR: Unable to find plugin: __ob__"
      if (videoOptions.plugins) {
        delete videoOptions.plugins.__ob__
      }
      // emit event
      const emitPlayerState = (event, value) => {
        if (event) {
          this.$emit(event, this.player)
        }
        if (value) {
          this.$emit(this.customEventName, { [event]: value })
        }
      }
      // player
      this.player = videojs(videoObj, videoOptions, function() {
        // events
        const DEFAULT_EVENTS = [
          'loadeddata',
          'canplay',
          'canplaythrough',
          'play',
          'pause',
          'waiting',
          'playing',
          'ended',
          'error'
        ]
        const events = DEFAULT_EVENTS.concat(self.events).concat(
          self.globalEvents
        )

        // watch events
        const onEdEvents = {}
        for (let i = 0; i < events.length; i++) {
          if (
            typeof events[i] === 'string' &&
            onEdEvents[events[i]] === undefined
          ) {
            ;((event) => {
              onEdEvents[event] = null
              this.on(event, () => {
                emitPlayerState(event, true)
              })
            })(events[i])
          }
        }
        // player readied
        self.$emit('ready', this)
      })
    },
    dispose(callback) {
      if (this.player && this.player.dispose) {
        if (this.player.techName_ !== 'Flash') {
          this.player.pause && this.player.pause()
        }
        this.player.dispose()
        this.player = null
        this.$nextTick(() => {
          this.reseted = false
          this.$nextTick(() => {
            this.reseted = true
            this.$nextTick(() => {
              callback && callback()
            })
          })
        })
      }
    }
  }
}
</script>

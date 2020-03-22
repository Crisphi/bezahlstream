<template>
  <div
    v-video-player:videoPlayer="playerOptions"
    class="video-player-box"
  ></div>
</template>

<script>
import { mapGetters } from 'vuex'

import 'video.js/dist/video-js.css'
import Vue from 'vue'

if (process.browser) {
  const VueVideoPlayer = require('vue-video-player/dist/ssr')
  Vue.use(VueVideoPlayer)
}

export default {
  props: {
    video: {
      type: Object,
      required: true
    }
  },
  computed: {
    ...mapGetters({
      videos: 'videos/get'
    }),
    videoFromStore() {
      // TODO: matching route with video from store
      return this.videos.find((v) => v.id === this.$route.params.id)
    },
    playerOptions() {
      return {
        language: 'en',
        playbackRates: [0.7, 1.0, 1.5, 2.0, 2.5, 3.0],
        sources: [
          {
            // type: 'video/mp4',
            // src: this.video.videoUrl
            type: 'video/mp4',
            src:
              'https://cdn.theguardian.tv/webM/2015/07/20/150716YesMen_synd_768k_vp8.webm'
          }
        ],
        poster: this.video.thumbnail,
        fluid: true
      }
    }
  }
}
</script>

<style lang="scss" scoped></style>

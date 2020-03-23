<template>
  <div>
    <div class="player">
      <CustomVideoJsPlayer
        ref="videoPlayer"
        class="vjs-custom-skin"
        :options="playerOptions"
        @play="onPlayerPlay($event)"
        @ready="onPlayerReady($event)"
      />
      <v-layout justify-center align-center>
        <v-container style="margin-top: -30px">
          <h1>Test Video</h1>
          <p>22,732 Aufrufe • 22. März 2020</p>

          <comments :comments="comments" />
        </v-container>
      </v-layout>
    </div>
  </div>
</template>

<script>
import CustomVideoJsPlayer from '~/components/CustomVideoJsPlayer.vue'
import Comments from '~/components/Comments.vue'

export default {
  components: {
    Comments,
    CustomVideoJsPlayer
  },
  data() {
    return {
      src:
        'https://bezahlstream.bitkomplex.de/video-demo/bbb_sunflower_1080p_30fps_normal/playlist.m3u8',
      playerOptions: {
        autoplay: true,
        controls: true,
        inactivityTimeout: 1000,
        controlBar: {
          timeDivider: false,
          durationDisplay: false
        }
        // poster: 'https://bezahlstream.bitkomplex.de/video-demo/bbb_sunflower_1080p_30fps_normal/playlist.jpg'
      },
      comments: [
        {
          avatar: 'https://cdn.vuetifyjs.com/images/lists/1.jpg',
          title: 'Brunch this weekend?',
          subtitle:
            "I'll be in your neighborhood doing errands this weekend. Do you want to hang out?"
        },
        {
          avatar: 'https://cdn.vuetifyjs.com/images/lists/2.jpg',
          title: 'Summer BBQ 4',
          subtitle: "Wish I could come, but I'm out of town this weekend."
        },
        {
          avatar: 'https://cdn.vuetifyjs.com/images/lists/3.jpg',
          title: 'Oui oui',
          subtitle: 'Do you have Paris recommendations? Have you ever been?'
        },
        {
          avatar: 'https://cdn.vuetifyjs.com/images/lists/4.jpg',
          title: 'Birthday gift',
          subtitle:
            'Have any ideas about what we should get Heidi for her birthday?'
        },
        {
          avatar: 'https://cdn.vuetifyjs.com/images/lists/5.jpg',
          title: 'Recipe to try',
          subtitle:
            'We should eat this: Grate, Squash, Corn, and tomatillo Tacos.'
        }
      ]
    }
  },
  computed: {
    player() {
      return this.$refs.videoPlayer.player
    }
  },
  mounted() {
    this.playVideo(this.src)
  },
  methods: {
    onPlayerPlay(player) {
      console.log('player play!', player)
    },
    onPlayerReady(player) {
      console.log('player ready!', player)
      this.player.play()
    },
    playVideo(source) {
      const video = {
        withCredentials: false,
        type: 'application/x-mpegurl',
        src: source
      }
      this.player.reset() // in IE11 (mode IE10) direct usage of src() when <src> is already set, generated errors,
      this.player.src(video)
      // this.player.load()
      this.player.play()
    }
  }
}
</script>

<style scoped>
.player {
  position: absolute !important;
  width: 100%;
  height: 100%;
}

.vjs-custom-skin {
  height: 90% !important;
}

.vjs-custom-skin /deep/ .video-js {
  width: 100% !important;
  height: 90%;
}
</style>

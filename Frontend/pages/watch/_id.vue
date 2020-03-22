<template>
  <v-container>
    <v-row>
      <v-col md="9" cols="12">
        <VideoWatch
          video="https://cdn.theguardian.tv/webM/2015/07/20/150716YesMen_synd_768k_vp8.webm"
          type="video/mp4"
        />
      </v-col>
      <v-col md="3" cols="12">
        <div class="display-1">Test video</div>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
import VideoWatch from '~/components/VideoWatch'

export default {
  components: {
    VideoWatch
  }
}
</script>

<style></style>

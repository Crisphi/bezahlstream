<template>
  <v-container>
    <h1>Videos</h1>
    <v-text-field v-model="search" hide-details label="Search" single-line />
    <ul>
      <li v-for="video in videos" :key="video.id">
        <a :href="`watch/${video.id}`">{{ video.name }}</a>
      </li>
    </ul>
  </v-container>
</template>

<script>
import { mapGetters } from 'vuex'

export default {
  data() {
    return {
      search: ''
    }
  },

  computed: {
    ...mapGetters({
      videos: 'videos/get'
    })
  }
}
</script>

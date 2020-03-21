<template>
  <v-layout justify-center align-center>
    <v-flex xs12 sm8 md6>
      <div class="text-center"></div>
      <v-card>
        <v-card-title class="headline"> Kanal von {{ id }} </v-card-title>
        <v-card-subtitle class="headline"
          >Herzlich Willkommen auf meinem Kanal
        </v-card-subtitle>
      </v-card>
    </v-flex>
  </v-layout>
</template>

<script>
export default {
  validate({ params }) {
    return /^.+$/.test(params.id)
  },
  asyncData({ params }) {
    return params
  }
}
</script>

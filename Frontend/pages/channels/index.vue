<template>
  <v-layout justify-center align-center>
    <v-flex xs12 sm8 md6>
      <Channel
        v-for="channel in channels"
        :key="channel.id"
        :channel="channel"
        class="channel-card"
      />
    </v-flex>
  </v-layout>
</template>

<script>
import Channel from '~/components/Channel.vue'

export default {
  components: {
    Channel
  },
  asyncData() {
    return {
      channels: [
        {
          id: 'id1',
          title: 'Mein Kanal',
          subtitle: 'Meine Beschreibung',
          subscripted: false
        },
        {
          id: 'id2',
          title: 'Best practices',
          subtitle: 'Look out!',
          subscripted: false
        },
        {
          id: 'id3',
          title: 'MyDummy',
          subtitle: 'sadfdfdgdg',
          subscripted: false
        }
      ]
    }
  }
}
</script>

<style scoped>
.channel-card {
  margin: 10px;
}
</style>

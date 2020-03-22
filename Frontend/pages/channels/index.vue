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
          avatar:
            'https://img.icons8.com/cute-clipart/512/000000/user-female.png',
          id: 'id1',
          title: 'Mein Kanal',
          subtitle: 'Meine Beschreibung',
          subscripted: false
        },
        {
          avatar:
            'https://img.icons8.com/cute-clipart/512/000000/user-male.png',
          id: 'id2',
          title: 'Best practices',
          subtitle: 'Look out!',
          subscripted: false
        },
        {
          avatar:
            'https://img.icons8.com/officel/512/000000/school-director-female-skin-type-4.png',
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
  margin: 16px;
}
</style>

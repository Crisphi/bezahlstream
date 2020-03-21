<template>
  <v-layout justify-center align-center>
    <v-flex xs12 sm8 md6>
      <div v-for="channel in channels" :key="channel.id" class="channel-card">
        <v-card outlined>
          <v-list-item three-line>
            <v-list-item-content>
              <v-list-item-title class="headline mb-1">
                {{ channel.title }}
              </v-list-item-title>
              <v-list-item-subtitle>
                {{ channel.subtitle }}
              </v-list-item-subtitle>
            </v-list-item-content>

            <v-list-item-avatar tile size="120" color="grey">
              <v-avatar>
                <v-icon dark>mdi-account-circle</v-icon>
              </v-avatar>
            </v-list-item-avatar>
          </v-list-item>

          <v-card-actions>
            <v-btn text @click="showChannel(channel)">Vorbeischauen</v-btn>
            <v-tooltip bottom>
              <template v-slot:activator="{ on }">
                <v-btn icon v-on="on" @click="subscribeTo(channel)">
                  <v-icon :disabled="!channel.subscripted">mdi-heart</v-icon>
                </v-btn>
              </template>
              <span v-if="channel.subscripted">Abbestellen</span>
              <span v-else>Abonieren</span>
            </v-tooltip>
          </v-card-actions>
        </v-card>
      </div>
    </v-flex>
  </v-layout>
</template>

<script>
export default {
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
  },
  methods: {
    showChannel(channel) {
      this.$router.push(`channels/${channel.id}`)
    },
    subscribeTo(channel) {
      channel.subscripted = !channel.subscripted
    }
  }
}
</script>

<style scoped>
.channel-card {
  padding: 8px;
}
</style>

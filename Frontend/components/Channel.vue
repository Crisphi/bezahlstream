<template>
  <v-card raised>
    <v-list-item three-line>
      <v-list-item-content>
        <v-list-item-title class="headline mb-1">
          {{ channel.title }}
        </v-list-item-title>
        <v-list-item-subtitle>
          {{ channel.subtitle }}
        </v-list-item-subtitle>
      </v-list-item-content>

      <v-list-item-avatar size="100" color="grey" rounded>
        <v-avatar size="72">
          <v-img :src="channel.avatar" />
        </v-avatar>
      </v-list-item-avatar>
    </v-list-item>

    <v-card-actions>
      <v-btn text :to="'/channels/' + channel.id">
        Vorbeischauen
      </v-btn>
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
</template>

<script>
export default {
  name: 'Channel',
  props: {
    channel: {
      type: Object,
      required: true
    }
  },
  methods: {
    subscribeTo(channel) {
      channel.subscripted = !channel.subscripted
    }
  }
}
</script>

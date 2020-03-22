<template>
  <v-layout justify-center align-center>
    <v-flex xs12 sm8 md6>
      <v-card>
        <v-card-title class="headline">Kanal von XYZ </v-card-title>
        <v-card-subtitle class="headline"
          >Herzlich Willkommen auf meinem Kanal
        </v-card-subtitle>
        <v-card-actions>
          <v-tooltip bottom>
            <template v-slot:activator="{ on }">
              <v-btn icon v-on="on">
                <v-icon disabled>mdi-heart</v-icon>
              </v-btn>
            </template>
            <span>Abonieren</span>
          </v-tooltip>
        </v-card-actions>
      </v-card>
      <br />
      <br />
      <br />
      <v-card>
        <v-card-title>Poetry Slam Nr. 2</v-card-title>
        <v-card-subtitle>schaut mal rein</v-card-subtitle>

        <v-card-actions>
          <v-btn>Vorschau</v-btn>
          <v-btn>Kaufen</v-btn>
        </v-card-actions>
      </v-card>
      <comments :comments="comments" />
    </v-flex>
  </v-layout>
</template>

<script>
import Comments from '~/components/Comments.vue'

export default {
  components: {
    Comments
  },
  validate({ params }) {
    return /^.+$/.test(params.id)
  },
  asyncData({ params }) {
    return {
      item: 5,
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
  }
}
</script>

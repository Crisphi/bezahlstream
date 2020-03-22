<template>
  <v-app dark>
    <v-navigation-drawer v-model="drawer" fixed app>
      <v-list>
        <v-list-item
          v-for="(item, i) in items"
          :key="i"
          :to="item.to"
          router
          exact
        >
          <v-list-item-content>
            <v-list-item-title v-text="item.title" />
          </v-list-item-content>
        </v-list-item>
      </v-list>
    </v-navigation-drawer>
    <v-app-bar fixed app>
      <v-app-bar-nav-icon @click.stop="drawer = !drawer" />
      <v-toolbar-title v-text="title" />
      <v-spacer />
    </v-app-bar>
    <v-content>
      <!-- <v-container>-->
      <nuxt />
      <!-- </v-container>-->
      <!-- <OnStaygeFooter/>-->
    </v-content>
    <!-- <v-footer fixed app>-->
    <!-- <span>&copy; {{ new Date().getFullYear() }}</span>-->
    <!-- </v-footer>-->
  </v-app>
</template>

<script>
// import OnStaygeFooter from '~/components/OnStaygeFooter.vue';

export default {
  components: {
    // OnStaygeFooter,
  },
  data() {
    return {
      drawer: false,
      items: [
        {
          title: 'Welcome',
          to: '/'
        },
        {
          title: 'Kanäle',
          to: '/channels'
        }
      ],
      title: 'OnStayge'
    }
  }
}
</script>

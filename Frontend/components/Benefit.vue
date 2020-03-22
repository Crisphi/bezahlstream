<template>
  <v-card class="mx-auto" max-width="344" outlined>
    <v-list-item three-line>
      <v-list-item-content class="center-content">
        <v-icon x-large color="orange darken-1">mdi-theater</v-icon>
        <v-list-item-title class="headline mb-1">{{ title }}</v-list-item-title>
        <v-list-item-subtitle v-html="body" />
      </v-list-item-content>
    </v-list-item>

    <v-card-actions class="center-action">
      <v-btn text>Mehr erfahren</v-btn>
    </v-card-actions>
  </v-card>
</template>

<script>
export default {
  props: ['title', 'body', 'icon']
}
</script>

<style scoped>
.center-content {
  text-align: center;
}
.center-action {
  display: flex;
  justify-content: center;
}
</style>

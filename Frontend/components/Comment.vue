<template>
  <v-list-item>
    <v-list-item-avatar>
      <v-img :src="comment.avatar" />
    </v-list-item-avatar>
    <v-list-item-content>
      <v-list-item-title>
        {{ comment.title }}
      </v-list-item-title>
      <v-list-item-subtitle>
        {{ comment.subtitle }}
      </v-list-item-subtitle>
    </v-list-item-content>
  </v-list-item>
</template>

<script>
export default {
  props: {
    comment: {
      type: Object,
      required: true
    }
  }
}
</script>

<style lang="scss" scoped></style>

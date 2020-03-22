<template>
  <v-list two-line avatar>
    <v-subheader>Kommentare</v-subheader>
    <v-list-item-group v-model="item" color="primary">
      <comment v-for="(comment, i) in comments" :key="i" :comment="comment" />
    </v-list-item-group>
  </v-list>
</template>

<script>
import Comment from '~/components/Comment.vue'

export default {
  components: {
    Comment
  },
  props: {
    comments: {
      type: Array,
      required: true
    }
  }
}
</script>

<style lang="scss" scoped></style>

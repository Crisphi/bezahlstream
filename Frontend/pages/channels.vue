<template>
  <nuxt-child></nuxt-child>
</template>

<script>
export default {
  middleware: ['auth'],
  options: {
    auth: false
  }
}
</script>

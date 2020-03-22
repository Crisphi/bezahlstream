<template>
  <div class="page-home">
    <v-parallax dark :src="bannerImg" height="720">
      <v-row align="center" justify="center">
        <v-col class="text-center" cols="12">
          <h1 class="cta-title display-1 font-weight-thin mb-4">OnStayge</h1>
          <h4 class="subheading cta-sub-title">
            Hole die Bühne der Künstler:innen ins Wohnzimmer
          </h4>
        </v-col>
      </v-row>
    </v-parallax>

    <v-container class="benefits">
      <v-row style="display: flex;justify-content: center;">
        <v-col
          v-for="benefit in benefits"
          :key="benefit.title"
          md="3"
          cols="12"
        >
          <benefit :title="benefit.title" :body="benefit.body"></benefit>
        </v-col>
      </v-row>
    </v-container>

    <v-parallax dark :src="middleImg" height="240">
      <v-row align="center" justify="center">
        <v-col class="text-center" cols="12">
          <h4 class="subheading cta-sub-title">
            Lorem ipsum dolor sit amet, consectetur adipisicing elit.
          </h4>
        </v-col>
      </v-row>
    </v-parallax>

    <h1
      class="display-1 font-weight-thin mb-4"
      style="text-align: center; margin-top: 2rem;"
    >
      Neuste Videos
    </h1>
    <v-container class="videos">
      <img
        v-for="img in 16"
        :key="img"
        class="video"
        src="~/assets/images/video-placeholder.png"
        alt="placeholder-image"
      />
    </v-container>

    <v-footer dark padless>
      <v-card flat tile class="indigo lighten-1 white--text text-center">
        <v-card-text>
          <v-btn
            v-for="icon in icons"
            :key="icon"
            class="mx-4 white--text"
            icon
          >
            <v-icon size="24px">{{ icon }}</v-icon>
          </v-btn>
        </v-card-text>

        <v-card-text class="white--text pt-0">
          Phasellus feugiat arcu sapien, et iaculis ipsum elementum sit amet.
          Mauris cursus commodo interdum. Praesent ut risus eget metus luctus
          accumsan id ultrices nunc. Sed at orci sed massa consectetur dignissim
          a sit amet dui. Duis commodo vitae velit et faucibus. Morbi vehicula
          lacinia malesuada. Nulla placerat augue vel ipsum ultrices, cursus
          iaculis dui sollicitudin. Vestibulum eu ipsum vel diam elementum
          tempor vel ut orci. Orci varius natoque penatibus et magnis dis
          parturient montes, nascetur ridiculus mus.
        </v-card-text>

        <v-divider></v-divider>

        <v-card-text class="white--text">
          <p><strong>Projekt unterstützt durch</strong></p>
          <img class="wirvsvirus" src="~/assets/images/wirvsvirus.png" alt="WirVvVirus" />
        </v-card-text>

        <v-card-text class="white--text">
          <strong>OnStayge</strong>
          <p>©️ {{ new Date().getFullYear() }}</p>
        </v-card-text>
      </v-card>
    </v-footer>
  </div>
</template>

<script>
import Benefit from '~/components/Benefit.vue'
import middleImg from '~/assets/images/ballet-1376250_1920.jpg'
import bannerImg from '~/assets/images/music-3507317_1920.jpg'

export default {
  components: {
    Benefit
  },
  data() {
    return {
      bannerImg,
      middleImg,
      benefits: [
        {
          title: 'Platform für Künstler',
          icon: 'mdi-heart',
          body:
            'Lorem ipsum dolor sit amet, consectetur adipisicing elit. ' +
            'Dolore, error explicabo in minus mollitia natus quibusdam ' +
            'quos sapiente vel voluptatum.'
        },
        {
          title: 'Theater on Demeand',
          icon: 'mdi-theater',
          body:
            'Lorem ipsum dolor sit amet, consectetur adipisicing elit. ' +
            'Dolore, error explicabo in minus mollitia natus quibusdam ' +
            'quos sapiente vel voluptatum.'
        },
        {
          title: 'Kostenfreie Registrierung',
          icon: 'mdi-currency-eur-off',
          body:
            'Lorem ipsum dolor sit amet, consectetur adipisicing elit. ' +
            'Dolore, error explicabo in minus mollitia natus quibusdam ' +
            'quos sapiente vel voluptatum.'
        }
      ],
      icons: [
        'mdi-facebook',
        'mdi-twitter',
        'mdi-google-plus',
        'mdi-linkedin',
        'mdi-instagram'
      ]
    }
  }
}
</script>

<style scoped>
.page-home {
  height: 100vh;
}

.cta-title {
  font-size: 4rem !important;
}

.cta-sub-title {
  font-size: 1.75rem !important;
  font-weight: 200;
}

.benefits {
  margin-top: 2rem;
  margin-bottom: 4rem;
}

.video {
  margin: 2rem;
  flex: 1 0 20%;
  height: 100%;
}

.videos {
  margin-top: 4rem;
  display: flex;
  flex-wrap: wrap;
  justify-content: space-between;
  align-items: center;
}

.something {
  margin-top: 4rem;
  background: #1c384e;
  height: 20rem;
  width: 100%;
}

.some-title {
  color: white;
  display: flex;
  justify-content: center;
  align-items: center;
  height: 20rem;
}

.wirvsvirus {
  width: 100%;
  max-width: 320px;
  height: auto;
}
</style>

<template>
  <div class="home">
    <div v-for="(blog,index) in pageOfBlogs" :key="blog.id + '_' + index">
      <article class="blog-article">
        <header class="blog-header">
          <span class="blog-meta">
            <time datetime="2019-09-30">30 SEP 2019</time>
          </span>
          <router-link :to="'/blog/' + blog.id">
            <h2 class="blog-title">{{ blog.title }}</h2>
          </router-link>
        </header>
        <section class="blog-excerpt">
          <p>{{ blog.content.substring(0,300) + "..." }}</p>
        </section>
      </article>
    </div>
    <div class="blog-page">
      <jw-pagination
        :items="blogs"
        @changePage="onChangePage"
        :labels="customLabels"
        :maxPages="5"
        :pageSize="5"
      ></jw-pagination>
    </div>
  </div>
</template>

<script>
import axios from "axios";

const customLabels = {
  first: "<<",
  last: ">>",
  previous: "<",
  next: ">"
};

export default {
  name: "home",
  data() {
    return {
      blogs: [],
      pageOfBlogs: [],
      customLabels
    };
  },
  methods: {
    getBlogs() {
      const path = process.env.VUE_APP_API_PATH + "blogs";
      axios
        .get(path)
        .then(res => {
          this.blogs = res.data;
        })
        .catch(error => {
          // eslint-disable-next-line
          console.error(error);
        });
    },
    onChangePage(pageOfBlogs) {
      this.pageOfBlogs = pageOfBlogs;
    }
  },
  created() {
    this.getBlogs();
  }
};
</script>

<style scoped>
.blog-article {
  position: relative;
  margin: 1rem auto;
  padding-bottom: 1rem;
  border-bottom: #ebf2f6 1px solid;
  word-break: break-word;
  hyphens: auto;
}

.blog-meta {
  font-size: 0.875rem;
  font-weight: 500;
  text-transform: uppercase;
  color: #575b5e;
}

.blog-title {
  font-size: 1.685rem;
  font-weight: 600;
  color: #222222;
}

.blog-page {
  background-color: white;
  text-align: center;
}
</style>

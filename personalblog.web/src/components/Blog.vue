<template>
  <div class="blog">
    <article class="blog-article">
      <header class="blog-header">
        <span class="blog-meta">
          <time>{{ blog.updatedAt | moment("DD MMM YYYY") }}</time>
        </span>&nbsp;
        <span class="blog-tags">{{ blog.tags }}</span>
        <h2 class="blog-title">{{ blog.title }}</h2>
      </header>
      <section class="blog-excerpt">
        <p class="blog-content" v-html="blog.content"></p>
      </section>
    </article>
  </div>
</template>

<script>
import axios from "axios";
import hljs from "highlight.js";

export default {
  name: "blog",
  data() {
    return {
      blog: {}
    };
  },
  methods: {
    getBlog() {
      const path =
        process.env.VUE_APP_API_PATH +
        "blogs/GetByTitleUrl/" +
        this.$route.params.titleurl;
      axios
        .get(path)
        .then(res => {
          var el = document.createElement("html");
          el.innerHTML = res.data.content;
          el.querySelectorAll("pre code").forEach(block => {
            hljs.highlightBlock(block);
          });
          res.data.content = el.getElementsByTagName("body")[0].innerHTML;
          this.blog = res.data;
        })
        .catch(error => {
          // eslint-disable-next-line
          console.error(error);
          this.$alert(
            "Something went wrong. Try again later!",
            "Error",
            "error"
          );
        });
    }
  },
  created() {
    this.getBlog();
  }
};
</script>

<style>
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

.blog-tags {
  font-size: 0.875rem;
  font-weight: 500;
  text-transform: uppercase;
  color: coral;
}

.blog-title {
  font-size: 2rem;
  font-weight: 600;
  color: #222222;
}

.blog-content pre {
  padding: 0.7rem 1rem !important;
  border-radius: 5px !important;
  background: #000 !important;
  color: #fff !important;
  font-size: 0.8rem !important;
  overflow-x: scroll !important;
}
.blog-content pre code {
  display: inline-block !important;
  padding: 0 0.4rem !important;
  border-radius: 5px !important;
  font-size: 0.8rem !important;
  font-weight: 400 !important;
  background: rgba(0, 0, 0, 0.1) !important;
  overflow-x: scroll !important;
}
</style>

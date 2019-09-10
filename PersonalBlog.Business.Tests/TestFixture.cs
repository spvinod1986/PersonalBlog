using System;
using System.Threading.Tasks;
using PersonalBlog.Persistence;

namespace PersonalBlog.Business.Tests
{
    public class TestFixture : IDisposable
    {
        public BlogContext Context { get; private set; }

        public TestFixture()
        {
            Context = BlogContextFactory.Create();

        }
        void IDisposable.Dispose()
        {
            BlogContextFactory.Destroy(Context);
        }
    }
}
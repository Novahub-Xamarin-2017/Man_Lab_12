using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace Exercise_2.Adapter
{
    public class MessageViewHolder : RecyclerView.ViewHolder
    {
        [InjectView(Resource.Id.tvMessage)] private TextView tvMessage;

        [InjectView(Resource.Id.tvUser)] private TextView tvUser;

        public string Message
        {
            set => tvMessage.Text = value;
        }

        public MessageViewHolder(View itemView) : base(itemView)
        {
            Cheeseknife.Inject(this, itemView);
        }
    }
}
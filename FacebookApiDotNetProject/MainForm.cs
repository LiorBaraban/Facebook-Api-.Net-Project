using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Facebook;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;
using static FacebookWrapper.ObjectModel.Post;
using FacebookApiDotNetProject_BeSocial_Logic;

namespace FacebookApiDotNetProject
{
    public partial class MainForm : Form
    {
        private BeSocialGameController m_GameController;
        private ActivitiesDecorator m_ActivitiesDecorator;
        private Action m_Publish;
        private LoginResult m_Result;
        private User m_User;
        private List<Control> m_ListOfGlobalControls = new List<Control>();
        private List<Control> m_ListOfFeature1Controls = new List<Control>();
        private List<Control> m_ListOfFeature1InnerControls = new List<Control>();
        private List<Control> m_ListOfFeature2Controls = new List<Control>();
        private bool m_IsLoggedIn = false;
        private eType m_ActivitySelectedType = eType.status;
        private Func<List<ISocialMission>, LinkedList<ISocialMission>> m_SelectedMissionStrategy;

        public MainForm()
        {
            InitializeComponent();
            FacebookService.s_CollectionLimit = 1000;
            m_ActivitiesDecorator = new ActivitiesDecorator();
            pictureBoxViralPic.BackgroundImageLayout = ImageLayout.Stretch;
            m_Publish = postStatus;
            m_SelectedMissionStrategy = MissionFactory.RandomizeMissionsOrder;
            updateMissionControls();
            assignControlsToLists();
        }

        private void assignControlsToLists()
        {
            m_ListOfGlobalControls.Add(pictureBoxProfile);
            m_ListOfGlobalControls.Add(labeUserName);
            m_ListOfFeature1InnerControls.Add(labelTagAFriend);
            m_ListOfFeature1InnerControls.Add(listBoxFriends);
            m_ListOfFeature1InnerControls.Add(buttonUnselectFriend);
            m_ListOfFeature1InnerControls.Add(pictureBoxSelectedFriend);
            m_ListOfFeature1InnerControls.Add(labelSelectedFriendName);
            m_ListOfFeature1InnerControls.Add(radioButtonLink);
            m_ListOfFeature1InnerControls.Add(radioButtonPicture);
            m_ListOfFeature1InnerControls.Add(radioButtonPostText);
            m_ListOfFeature1InnerControls.Add(buttonSelectPicture);
            m_ListOfFeature1InnerControls.Add(textBoxURL);
            m_ListOfFeature1InnerControls.Add(labelAddress);
            m_ListOfFeature1InnerControls.Add(labelPostText);
            m_ListOfFeature1InnerControls.Add(textBoxPost);
            m_ListOfFeature1InnerControls.Add(labelCharCount);
            m_ListOfFeature1InnerControls.Add(labelCounter);
            m_ListOfFeature1InnerControls.Add(buttonPublish);
            m_ListOfFeature1InnerControls.Add(labelScore);
            m_ListOfFeature2Controls.Add(buttonFetchViralPhoto);
            m_ListOfFeature2Controls.Add(pictureBoxViralPic);
            m_ListOfFeature2Controls.Add(labelViralDesc);
            m_ListOfFeature2Controls.Add(labelDesiredActivity);
            m_ListOfFeature2Controls.Add(radioButtonMostViralPicture);
            m_ListOfFeature2Controls.Add(radioButtonMostViralPost);
            m_ListOfFeature2Controls.Add(radioButtonMostViralLink);
            m_ListOfFeature1Controls.Add(radioButtonRandomMissionOrder);
            m_ListOfFeature1Controls.Add(radioButtonOrderFromEasyToHard);
            m_ListOfFeature1Controls.Add(radioButtonOnlyHardMissions);
            foreach (Control control in m_ListOfGlobalControls)
            {
                control.Visible = false;
            }
            foreach (Control control in m_ListOfFeature1Controls)
            {
                control.Visible = false;
            }
            foreach (Control control in m_ListOfFeature1InnerControls)
            {
                control.Visible = false;
            }

            foreach (Control control in m_ListOfFeature2Controls)
            {
                control.Visible = false;
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                bool isWantToBeVisible = false;

                if (m_IsLoggedIn == false)
                {
                    new Thread(login).Start();
                    m_IsLoggedIn = true;
                    isWantToBeVisible = true;
                    updateVisibilityOfControls(m_ListOfGlobalControls, true);
                    updateVisibilityOfControls(m_ListOfFeature1Controls, isWantToBeVisible);
                    updateVisibilityOfControls(m_ListOfFeature2Controls, isWantToBeVisible);
                    buttonLogin.Text = "Log Out";
                }
                else
                {
                    bool isGameStillRunning = false;
                    if (m_GameController != null)
                    {
                        isGameStillRunning = true;
                    }

                    if (!isGameStillRunning || (isGameStillRunning && isWantToLeaveGame()))
                    {
                        FacebookWrapper.FacebookService.Logout(null);
                        m_IsLoggedIn = false;
                        updateVisibilityOfControls(m_ListOfGlobalControls, false);
                        updateVisibilityOfControls(m_ListOfFeature1Controls, false);
                        updateVisibilityOfControls(m_ListOfFeature2Controls, false);
                        updateVisibilityOfControls(m_ListOfFeature1InnerControls, false);
                        clearControls();
                        buttonLogin.Text = "Log In";
                        MessageBox.Show("Logged out successfully");
                    }
                    else
                    {
                        MessageBox.Show("You did not log out. Now you can finish your game");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Oops! something went wrong.");
            }
        }

        private void updateVisibilityOfControls(List<Control> i_ListOfControls, bool isWantToBeVisible)
        {
            foreach (Control control in i_ListOfControls)
            {
                control.Visible = isWantToBeVisible;
            }
        }

        private bool isWantToLeaveGame()
        {
            bool isWantToLeave = false;
            DialogResult dialogRes = MessageBox.Show("A game is still running. Are you sure you want to log out?", "Wait", MessageBoxButtons.YesNo);
            if (dialogRes == DialogResult.Yes)
            {
                isWantToLeave = true;
            }

            return isWantToLeave;
        }

        private void clearControls()
        {
            friendListBindingSource.Clear();
            labelCounter.Text = null;
            textBoxPost.Text = null;
            textBoxURL.Text = null;
            albumsBindingSource1.Clear();
            pictureBoxViralPic.BackgroundImage = null;
            labelViralDesc.Text = null;
        }

        private void login()
        {
            buttonLogin.Invoke(new Action(() => m_Result = FacebookWrapper.FacebookService.Login(
                "495677157474019",
                "user_education_history",
                "user_birthday",
                "user_actions.video",
                "user_actions.news",
                "user_actions.music",
                "user_actions.fitness",
                "user_actions.books",
                "user_about_me",
                "user_friends",
                "publish_actions",
                "user_events",
                "user_games_activity",
                "user_hometown",
                "user_likes",
                "user_location",
                "user_managed_groups",
                "user_photos",
                "user_posts",
                "user_relationships",
                "user_relationship_details",
                "user_religion_politics",
                "user_tagged_places",
                "user_videos",
                "user_website",
                "user_work_history",
                "read_custom_friendlists",
                "read_page_mailboxes",
                "manage_pages",
                "publish_pages",
                "publish_actions",
                "rsvp_event")));

            m_User = m_Result.LoggedInUser;
            updateLoginProfile();
        }

        private void updateLoginProfile()
        {
            pictureBoxProfile.Image = m_User.ImageNormal;
            labeUserName.Invoke(new Action(() => labeUserName.Text =
            string.Format("{0},{1}", m_User.FirstName, m_User.LastName)));
            updateLists();
        }

        private void updateLists()
        {
            listBoxFriends.Invoke(new Action(() => friendListBindingSource.DataSource = m_User.Friends));
            listBoxAlbums.Invoke(new Action(() => albumsBindingSource1.DataSource = m_User.Albums));
            listBoxFriends.DisplayMember = "Name";
        }

        private void buttonUnselectFriend_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_User == null)
                {
                    throw new Exception("You must be logged in first");
                }

                listBoxFriends.ClearSelected();
                if (m_GameController != null)
                {
                    m_GameController.Model.SelectedFriend = null;
                }

                displaySelectedFriend();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Oops! Something went wrong");
            }
        }

        private void displaySelectedFriend()
        {
            if (listBoxFriends.SelectedItems.Count == 1)
            {
                User selectedFriend = listBoxFriends.SelectedItem as User;
                if (selectedFriend.PictureNormalURL != null)
                {
                    pictureBoxSelectedFriend.LoadAsync(selectedFriend.PictureNormalURL);
                    labelSelectedFriendName.Text = selectedFriend.Name;
                }
                else
                {
                    pictureBoxSelectedFriend.Image = pictureBoxSelectedFriend.ErrorImage;
                }
            }
            else
            {
                pictureBoxSelectedFriend.Image = null;
                labelSelectedFriendName.Text = null;
            }
        }

        private void buttonStartGame_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_User == null)
                {
                    throw new Exception("You must log in first!");
                }

                startGame();
                buttonStartGame.Enabled = false;
                updateVisibilityOfControls(m_ListOfFeature1Controls, false);
                updateVisibilityOfControls(m_ListOfFeature1InnerControls, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Something went wrong");
            }
        }

        private void startGame()
        {
            updateVisibilityOfControls(m_ListOfFeature1Controls, false);
            createANewGameController();
            updateMissionControls();
        }

        private void createANewGameController()
        {
            m_GameController = BeSocialGameController.Instance(this.m_SelectedMissionStrategy);
            m_GameController.Model.PostText = textBoxPost.Text;
            m_GameController.Model.SelectedFriend = listBoxFriends.SelectedItem as User;
            if (!string.IsNullOrEmpty(textBoxURL.Text))
            {
                if (radioButtonLink.Checked == true)
                {
                    m_GameController.Model.LinkUrl = textBoxURL.Text;
                }
                else if (radioButtonPicture.Checked == true)
                {
                    m_GameController.Model.PictureUrl = textBoxURL.Text;
                }
            }
            m_GameController.m_EndTurn += this.Turn_Ended;
            updateMissionControls();
        }

        private void Turn_Ended(object sender, FinishTurnEventArgs e)
        {
            if (m_GameController != null)
            {
                bool isVictory = false;
                string finishMessage = null;
                if (e.IsFinishedGame || e.IsFinishedGame)
                {
                    if (e.IsReachedMaxPoints)
                    {
                        isVictory = true;
                        finishMessage = string.Format(@"Congrats! you have beaten the game with the score: {0}", m_GameController.PlayerScore);
                    }
                    else if (e.IsFinishedGame)
                    {
                        isVictory = false;
                        finishMessage = string.Format(
        @"Sorry, you've reached the end of the game but didn't beat it.
You only needed {0} nore points.",
        m_GameController.MaxScore - m_GameController.PlayerScore);

                    }
                    finishGame(isVictory, finishMessage);
                }
            }
        }

        private void buttonEndGame_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_GameController == null)
                {
                    throw new Exception("The game must be started first");
                }

                bool isVictory = false;
                string message = string.Format(
        @"You've decided to end the game.
Your score is {0}.
See you next time",
        m_GameController.PlayerScore);
                finishGame(isVictory, message);
                m_GameController = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Oops, something went wrong");
            }
        }

        private void buttonSkipMission_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_GameController == null)
                {
                    throw new Exception("The game must be started first");
                }

                string msgBody = @"Are you sure you want to skip this mission?
You won't get any points!";
                DialogResult msgResult = MessageBox.Show(msgBody, "Wait", MessageBoxButtons.YesNo);
                if (msgResult == DialogResult.Yes)
                {
                    m_GameController.OnEndTurn();
                    //startNextRound(false);
                    updateMissionControls();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Oops, something went wrong");
            }
        }

        private void startNextRound(bool i_IsFulfilled)
        {
            //$$2 move this logic into game controller.
            if (i_IsFulfilled)
            {
                m_GameController.RewardPoints();
            }
            if (m_GameController.IsReachedMaxPoints() || m_GameController.CurrentMissionNode.Next == null)
            {
                //$$3 the bool should be an event arg passed by the logic to the ui
                bool isVictory;
                //$$4 the finish message should be implemented in ui handle_RoundEnded which is registered to the m_Gamecontroller's event (+=)
                string finishMessage = null;
                //$$5 same as 4
                if (m_GameController.IsReachedMaxPoints())
                {
                    isVictory = true;
                    finishMessage = string.Format(@"Congrats! you have beaten the game with the score: {0}", m_GameController.PlayerScore);
                }
                else //$$6 same as 4
                {
                    isVictory = false;
                    finishMessage = string.Format(
        @"Sorry, you've reached the end of the game but didn't beat it.
You only needed {0} nore points.",
        m_GameController.MaxScore - m_GameController.PlayerScore);
                }

                finishGame(isVictory, finishMessage);
            }
            else //$$7 should be based on the e.args passed by the logic
            {
                m_GameController.SkipToNextMission();
            }
        }

        private void finishGame(bool i_IsVictory, string i_FinishMessage)
        {
            updateMissionControls();
            MessageBox.Show(i_FinishMessage);
            if (i_IsVictory)
            {
                shareScore();
            }
            m_GameController.ResetMissions();
            m_GameController = null;
            buttonStartGame.Enabled = true;
            updateMissionControls();
            updateVisibilityOfControls(m_ListOfFeature1InnerControls, false);
            updateVisibilityOfControls(m_ListOfFeature1Controls, true);
        }

        private void shareScore()
        {
            string message = "Do you want to share your final score in BeMoreSocial?";
            DialogResult messageResult = MessageBox.Show(message, null, MessageBoxButtons.YesNo);
            if (messageResult == DialogResult.Yes)
            {
                string post = string.Format(@"I Finished BeMoreSocial and scored {0} Points!", m_GameController.PlayerScore);
                new Thread(() => m_User.PostStatus(post)).Start();
                MessageBox.Show(@"Your BeMoreSocial score was shared! 
See you next time!");
            }
            else
            {
                MessageBox.Show(@"Okay, See you next time!");
            }
        }

        private void updateMissionControls()
        {
            string strMessage = null;
            if (m_GameController == null)
            {
                labelMissionDescription.Text = @"Welcome to BeMoreSocial!
The game that will make you more social and viral in your social network.

Your goal is to reach a total of 10 or more social points per game.
You earn points by doing social 'missions' that the app tells you to do.

Press 'Start Game' whenever You're ready to play. Good Luck!";
                labelScore.Text = null;
            }
            else
            {
                if (m_GameController.CurrentMissionNode != null)
                {
                    strMessage = m_GameController.CurrentMission.Description;
                }
                else
                {
                    strMessage = string.Format("The game has ended. your score is {0}", m_GameController.PlayerScore);
                }

                labelScore.Text = string.Format("Current Game Score: {0}", m_GameController.PlayerScore.ToString());
                labelMissionDescription.Text = strMessage;
                textBoxPost.Text = null;
                textBoxURL.Text = null;
                listBoxFriends.ClearSelected();
                displaySelectedFriend();
            }
        }

        private void radioButtonPostText_CheckedChanged(object sender, EventArgs e)
        {
            labelAddress.Text = string.Empty;
            textBoxURL.Enabled = false;
            textBoxURL.Text = string.Empty;
            buttonSelectPicture.Enabled = false;
            labelPostText.Text = "Post Text:";
            m_Publish = postStatus;
        }

        private void radioButtonLink_CheckedChanged(object sender, EventArgs e)
        {
            labelAddress.Text = "Online Picture / Link Address:";
            textBoxURL.Enabled = true;
            textBoxURL.Text = string.Empty;
            buttonSelectPicture.Enabled = false;
            buttonSelectPicture.Enabled = false;
            labelPostText.Text = "Additional Text:";
            m_Publish = postStatus;
        }

        private void radioButtonPicture_CheckedChanged(object sender, EventArgs e)
        {
            labelAddress.Text = "Local Picture Address:";
            textBoxURL.Enabled = true;
            textBoxURL.Text = string.Empty;
            buttonSelectPicture.Enabled = true;
            labelPostText.Text = "Picture Title:";
            m_Publish = postPicture;
        }

        private void buttonSelectPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Image files (*.jpg, *.jpeg, *.png, *.gif) | *.jpg; *.jpeg; *.png; *.gif;";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                textBoxURL.Text = openFile.FileName;
            }
        }

        private void textBoxURL_TextChanged(object sender, EventArgs e)
        {
            if (m_GameController != null)
            {
                if (radioButtonLink.Checked == true)
                {
                    m_GameController.Model.LinkUrl = textBoxURL.Text;
                    m_GameController.Model.PictureUrl = null;
                }
                else if (radioButtonPicture.Checked == true)
                {
                    m_GameController.Model.LinkUrl = null;
                    m_GameController.Model.PictureUrl = textBoxURL.Text;
                }
                else if (radioButtonPostText.Checked == true)
                {
                    m_GameController.Model.LinkUrl = null;
                    m_GameController.Model.PictureUrl = null;
                }
            }
        }

        private void textBoxPost_TextChanged(object sender, EventArgs e)
        {
            if (m_GameController != null)
            {
                m_GameController.Model.PostText = textBoxPost.Text;
            }

            labelCounter.Text = textBoxPost.TextLength.ToString();
        }

        private void postStatus()
        {
            StringBuilder statusText = new StringBuilder();
            statusText.Append(m_GameController.Model.PostText);
            updateGameModel();
            if (m_GameController.IsCurrentMissionFullfilled())
            {
                statusText.Append(Environment.NewLine);
                statusText.Append(string.Format("I Won {0} points in BeMoreSocial", m_GameController.CurrentMission.ScoreValue));
            }

            string taggedFriendId = null;
            if (m_GameController.Model.SelectedFriend != null)
            {
                taggedFriendId = m_GameController.Model.SelectedFriend.Id;
            }

            string linkURL = m_GameController.Model.LinkUrl;
            try
            {
                if (string.IsNullOrEmpty(statusText.ToString()) && string.IsNullOrEmpty(taggedFriendId) && string.IsNullOrEmpty(linkURL))
                {
                    throw new Exception("Not enough parameters to publish any kind of post!");
                }

                new Thread(() => m_User.PostStatus(
                    statusText.ToString(), null, null, taggedFriendId, linkURL)).Start();
                MessageBox.Show("Posted a status to facebook");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Oops, Something went wrong!");
            }
        }

        private void postPicture()
        {
            updateGameModel();
            string photoURL = m_GameController.Model.PictureUrl;
            string photoDescription = m_GameController.Model.PostText;
            try
            {
                new Thread(() => m_User.PostPhoto(photoURL, photoDescription, null)).Start();
                MessageBox.Show("Posted a photo to facebook");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonPublish_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_User == null)
                {
                    throw new Exception("You have to be logged in first!");
                }

                if (m_GameController == null)
                {
                    throw new Exception("You have to Start the game first!");
                }

                if (isWantToUploadToFacebook())
                {
                    updateGameModel();
                    m_Publish();
                    //$$1 raise event round ended in game controller
                    m_GameController.OnEndTurn();
                    //startNextRound(m_GameController.IsCurrentMissionFullfilled());
                    updateMissionControls();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Oops! something went wrong...");
            }
        }

        private void updateGameModel()
        {
            m_GameController.UpdateGameModel(new GameModel
            {
                LinkUrl = textBoxURL.Text,
                PictureUrl = textBoxURL.Text,
                PostText = textBoxPost.Text,
                SelectedFriend = listBoxFriends.SelectedItem as User
            });

        }

        private bool isWantToUploadToFacebook()
        {
            bool isWantToUpload = false;
            string inner, title;
            updateGameModel();
            if (m_GameController.IsCurrentMissionFullfilled())
            {
                title = "Good Work!";
                inner = string.Format(
        @"Good work! Mission is about to complete!

If you upload it to facebook you will get {0} points!

Do you wish to upload to Facebook and get the points?",
        m_GameController.CurrentMission.ScoreValue);
            }
            else
            {
                title = "Not good...";
                inner = @"Sorry, You didn't follow the instructions.

If you decide to publish to Facebook you won't get any points. 

Do you still wish to continue and upload to facebook?";
            }

            DialogResult msgResult = MessageBox.Show(inner, title, MessageBoxButtons.YesNo);
            if (msgResult == DialogResult.Yes)
            {
                isWantToUpload = true;
            }

            return isWantToUpload;
        }

        private void buttonFetchViralActivity_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_User == null)
                {
                    throw new Exception("You must be logged in first");
                }

                if (m_ActivitySelectedType == eType.photo)
                {

                    if (listBoxAlbums.SelectedIndex < 0)
                    {
                        throw new Exception("You must choose an album first");
                    }
                    else
                    {
                        m_ActivitiesDecorator.ActivityCollection = ((listBoxAlbums.SelectedItem as Album).Photos as IEnumerable<PostedItem>).ToList();
                    }
                }
                else
                {
                    m_ActivitiesDecorator.ActivityCollection = ((m_User.Posts) as IEnumerable<PostedItem>)
                    .Where(p => p.From.Id.Equals(m_User.Id)
                    && (p as Post).Type == m_ActivitySelectedType)
                    .ToList();
                }
                labelViralDesc.Text = "Loading, This might taka a moment...";
                new Thread(GetMostViralActivity).Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GetMostViralActivity()
        {
            string shareMessage = null;
            string linkUrl = null;
            try
            {
                m_ActivitiesDecorator.FindMostViralActivity();
                pictureBoxViralPic.Invoke(new Action(() => pictureBoxViralPic.Image = null));
                if (m_ActivitiesDecorator.Activity is Photo)
                {
                    pictureBoxProfile.Invoke(new Action(() => pictureBoxProfile.Visible = true));
                    pictureBoxViralPic.Invoke(new Action(() => pictureBoxViralPic.BackgroundImage = (m_ActivitiesDecorator.Activity as Photo).ImageNormal));
                    labelViralDesc.Invoke(new Action(() => labelViralDesc.Text = string.Format(
                            "Likes: {0}", m_ActivitiesDecorator.Likes)));
                    shareMessage = string.Format(@"This was my most viral photo in '{0}' album.
It got {1} Likes!",
        (m_ActivitiesDecorator.Activity as Photo).Album.Name,
        m_ActivitiesDecorator.Likes);
                    linkUrl = (m_ActivitiesDecorator.Activity as Photo).Link;
                }
                else if (m_ActivitiesDecorator.Activity is Post)
                {
                    pictureBoxProfile.Invoke(new Action(() => pictureBoxProfile.Visible = false));

                    if ((m_ActivitiesDecorator.Activity as Post).Type == eType.status)
                    {
                        labelViralDesc.Invoke(new Action(() => labelViralDesc.Text = string.Format(@"Post:{0}
Likes:{1}", (m_ActivitiesDecorator.Activity as Post).Message, m_ActivitiesDecorator.Likes)));
                        shareMessage = string.Format(@"This was my most viral post:
'{0}'.
It was published in {1}
It got {2} Likes",
        (m_ActivitiesDecorator.Activity as Post).Message,
        (m_ActivitiesDecorator.Activity as Post).UpdateTime,
        m_ActivitiesDecorator.Likes
        );
                    }
                    else if ((m_ActivitiesDecorator.Activity as Post).Type == eType.link)
                    {
                        labelViralDesc.Invoke(new Action(() => labelViralDesc.Text = string.Format(@"Link:{0}
Likes:{1}", (m_ActivitiesDecorator.Activity as Post).Link, m_ActivitiesDecorator.Likes)));
                        shareMessage = string.Format(@"This was my most viral shared link:
'{0}'.
It was published in {1}
It got {2} Likes",
        (m_ActivitiesDecorator.Activity as Post).Link,
        (m_ActivitiesDecorator.Activity as Post).UpdateTime,
        m_ActivitiesDecorator.Likes
        );
                    }
                }
                checkIfWantToShareMostViral(shareMessage, linkUrl);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Oops, Something went wrong!");
            }
        }

        private void checkIfWantToShareMostViral(string i_ShareMessage, string i_LinkUrl)
        {
            DialogResult messageResult = MessageBox.Show("Do you want to share this on facebook?", "Share your mos viral activity", MessageBoxButtons.YesNo);
            if (messageResult == DialogResult.Yes)
            {
                try
                {
                    m_User.PostStatus(i_ShareMessage, null, null, null, i_LinkUrl);
                    MessageBox.Show("Posted to facebook!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Oops, Something went wrong!");
                }
            }
            else
            {
                MessageBox.Show("Okay, did not post");
            }
        }

        private void radioButtonMostViralPost_CheckedChanged(object sender, EventArgs e)
        {
            m_ActivitySelectedType = eType.status;
            listBoxAlbums.Visible = false;
        }

        private void radioButtonMostViralLink_CheckedChanged(object sender, EventArgs e)
        {
            m_ActivitySelectedType = eType.link;
            listBoxAlbums.Visible = false;
        }

        private void radioButtonMostViralPicture_CheckedChanged(object sender, EventArgs e)
        {
            m_ActivitySelectedType = eType.photo;
            listBoxAlbums.Visible = true;
        }

        private void radioButtonRandomMissionOrder_CheckedChanged(object sender, EventArgs e)
        {
            m_SelectedMissionStrategy = MissionFactory.RandomizeMissionsOrder;
        }

        private void radioButtonOrderFromEasyToHard_CheckedChanged(object sender, EventArgs e)
        {
            m_SelectedMissionStrategy = MissionFactory.OrderMissionsFromEasyToHard;
        }

        private void radioButtonOnlyHardMissions_CheckedChanged(object sender, EventArgs e)
        {
            m_SelectedMissionStrategy = MissionFactory.OnlyHardMissions;
        }
    }
}
